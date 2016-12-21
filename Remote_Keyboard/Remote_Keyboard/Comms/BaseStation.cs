using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets; //for UdpClient
using System.Net; //for IPEndPoint
using System.Timers; //for broadcast events
using System.Linq;
using Remote_Keyboard.Common;
using System.ComponentModel;


/*
-----How to refer to different plateforms-------
#if __IOS__
using UIKit;
#elif __ANDROID__
using Android.OS;
#elif WINDOWS_APP || WINDOWS_PHONE_APP || WINDOWS_UWP
using Windows.Security.ExchangeActiveSyncProvisioning;
#endif
*/


namespace Remote_Keyboard.Comms
{
    class BaseStation
    {
        private static BaseStation instance = null;

        //private UdpClient udpConnection;
        private Timer brdcstTmr;
        private string brdcstMsg;
        private double timeOutMilliSec = 3e3;

        //stores other peers on the network
        private List<Peer> knownPeers;
        private HeartBeat myHeartBeat;

        //peer change event
        public event EventHandler<PeerUpdateEventArgs> PeerChanged;
        public event EventHandler<KeyStrokeEventArgs> KeyStrokeReceived;
        public BackgroundWorker test;

        //constructor
        public BaseStation()
        {
            this.knownPeers = new List<Peer>();
            this.myHeartBeat = new HeartBeat
            {
                senderIpAddress = this.GetLocalIPAddress().ToString(),
                acceptKeyStrokes = true,
                acceptCopySync = true,
                platform = OSValue.Windows10
            };

            test = new BackgroundWorker();
            test.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(Test_RunWorkerCompleted);

            int timeIntrvlMilliSec = 3000;
            PeerConnection.MsgReceived += PeerConnectionMsgReceived;
            StartBroadcasting(timeIntrvlMilliSec);
        }

        private void PeerConnectionMsgReceived(object sender, MsgReceivedEventArgs e)
        {
            MessageType objType = XMLParser.GetType(e.message);
            switch (objType)
            {
                case MessageType.HeartBeat:
                    HeartBeat heartBeatObj = XMLParser.DeserializeObject<HeartBeat>(e.message);
                    this.ReceivedHeartBeat(heartBeatObj);
                    break;

                case MessageType.KeyStroke:
                    KeyStrokeMsg keyStrkObj = XMLParser.DeserializeObject<KeyStrokeMsg>(e.message);
                    this.RecievedKeyStrokeMsg(keyStrkObj);
                    break;

                default:
                    Console.WriteLine("Basestation: unknown object type");
                    break;
            }
        }

        private void StartBroadcasting(int timeIntrvlMilliSec)
        {
            //populate broadcast message
            this.brdcstMsg = XMLParser.SerializeObject(this.myHeartBeat);
            
            //setup reoccuring broadcast
            this.brdcstTmr = new Timer( );
            this.brdcstTmr.Interval = timeIntrvlMilliSec;
            this.brdcstTmr.Elapsed += new ElapsedEventHandler(BroadCastEvent);
            this.brdcstTmr.Start();
        }

        private void BroadCastEvent(object sender, ElapsedEventArgs e)
        {
            PeerConnection.SendBroadcastAsync(this.brdcstMsg);
        }

        private void ReceivedHeartBeat(HeartBeat hrtBtMsg)
        {
            //update timer for corresponding peer

            bool fromThisPeer = string.Equals(hrtBtMsg.senderIpAddress, this.myHeartBeat.senderIpAddress);
            bool fromExistingPeer = IsIpAddressKnown(hrtBtMsg.senderIpAddress);
            if (!fromThisPeer && !fromExistingPeer)
            {
                //establish TCP connection with that peer
                Peer latestPeer = new Peer(hrtBtMsg, timeOutMilliSec);
                latestPeer.aliveTimeout.Elapsed += AliveTimeoutElapsed;

                knownPeers.Add(latestPeer);

                //broadcast again so other peers can quickly discover this peer
                PeerConnection.SendBroadcastAsync(this.brdcstMsg);

                //send out a broadcast to all subscribers
                PeerChanged?.Invoke(this, new PeerUpdateEventArgs(knownPeers));
            }
        }

        private void AliveTimeoutElapsed(object sender, ElapsedEventArgs e)
        {
            //TODO - test if this updates the peer in the list of peers
            Timer inactivePeerTimer = (Timer)sender;
            foreach(Peer peer in knownPeers)
            {
                bool sameTimer = inactivePeerTimer.Equals(peer.aliveTimeout);
                if(sameTimer)
                {
                    peer.activePeer = false;
                }
            }

            //TODO - DANGER, running in another thread. Can't edit windows forms elements!!!!!!!!!!!!!!!
            test.RunWorkerAsync();
            //PeerChanged?.Invoke(this, new PeerUpdateEventArgs(knownPeers));
        }

        private void Test_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PeerChanged?.Invoke(this, new PeerUpdateEventArgs(knownPeers));
        }


        private void RecievedKeyStrokeMsg(KeyStrokeMsg kyStrkMsg)
        {
            KeyStrokeReceived?.Invoke(this, new KeyStrokeEventArgs(kyStrkMsg));
        }

        /*
        //non-blocking
        private async void SendMessageAsync(string ipAddress, string message)
        {
            IPAddress ipAddressObj = IPAddress.Parse(ipAddress);
            IPEndPoint endPoint = new IPEndPoint(ipAddressObj, this.portNum);
            byte[] datagram = Encoding.ASCII.GetBytes(message);

            await udpConnection.SendAsync(datagram, datagram.Length, endPoint);
        }
        */

        public void SendMessageToAllPeers(string message)
        {
            foreach(Peer peer in knownPeers)
            {
                peer.peerConnection.SendMessageToPeer(message);         
            }
        }

        private bool IsIpAddressKnown(String testIp)
        {
            foreach(Peer curPeer in knownPeers)
            {
                if(string.Equals(curPeer.lastHeartBeat.senderIpAddress, testIp))
                {
                    return true;
                }
            }
            return false;
        }

        private IPAddress GetLocalIPAddress()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            return host
                .AddressList
                .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
        }
    }
}