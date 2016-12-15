using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets; //for UdpClient
using System.Net; //for IPEndPoint
using System.Timers; //for broadcast events
using System.Linq;
using Remote_Keyboard.Common;


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
    //singleton class
    //one BaseStation is used to send and retrieve data
    //singleton
    class BaseStation
    {
        private static BaseStation instance = null;

        private UdpClient udpConnection;
        private int portNum;
        private Timer brdcstTmr;
        private string brdcstMsg;
        private double timeOutMilliSec = 10e3;

        //stores other peers on the network
        private List<Peer> knownPeers;
        private HeartBeat myHeartBeat;

        //peer change event
        public event EventHandler<PeerUpdateEventArgs> PeerChanged;
        public event EventHandler<KeyStrokeEventArgs> KeyStrokeReceived;

        //factory method
        public static BaseStation GetInstance(int portNum)
        {
            if(instance != null)
            {
                return instance;
            }

            //create a new instance
            instance = new BaseStation(portNum);
            return instance;
        }

        //constructor
        private BaseStation( int mPortNum)
        {
            InitializeVariables(mPortNum);

            int timeIntrvlMilliSec = 3000;
            StartingListeningAsync();
            StartBroadcasting(timeIntrvlMilliSec);
        }

        //deconstructor
        ~BaseStation()
        {
            this.udpConnection.Close();
        }

        private void InitializeVariables(int mPortNum)
        {
            this.knownPeers = new List<Peer>();
            this.portNum = mPortNum;
            this.udpConnection = new UdpClient(portNum);
            this.myHeartBeat = new HeartBeat
            {
                senderIpAddress = this.GetLocalIPAddress().ToString(),
                acceptKeyStrokes = true,
                acceptCopySync = true,
                platform = OSValue.Windows10
            };
        }

        private void StartBroadcasting(int timeIntrvlMilliSec)
        {
            //populate broadcast message
            this.brdcstMsg = XMLParser.SerializeObject(this.myHeartBeat);
            //HeartBeat temp = XMLParser.DeserializeObject<HeartBeat>(brdcstMsg);
            
            //setup reoccuring broadcast
            this.brdcstTmr = new Timer( );
            this.brdcstTmr.Interval = timeIntrvlMilliSec;
            this.brdcstTmr.Elapsed += new ElapsedEventHandler(BroadCastEvent);
            this.brdcstTmr.Start();
        }

        private void BroadCastEvent(object sender, ElapsedEventArgs e)
        {
            this.SendBroadcastAsync(this.brdcstMsg);
        }

        //non-blocking
        public async void StartingListeningAsync()
        {
            while (true)
            {
                //read received message
                UdpReceiveResult result = await this.udpConnection.ReceiveAsync();
                string message = Encoding.ASCII.GetString(result.Buffer);
                MessageType objType = XMLParser.GetType(message);

                switch (objType)
                {
                    case MessageType.HeartBeat:
                        HeartBeat heartBeatObj = XMLParser.DeserializeObject<HeartBeat>(message);
                        this.ReceivedHeartBeat(heartBeatObj);
                        break;

                    case MessageType.KeyStroke:
                        KeyStrokeMsg keyStrkObj = XMLParser.DeserializeObject<KeyStrokeMsg>(message);
                        this.RecievedKeyStroke(keyStrkObj);
                        break;

                    default:
                        Console.WriteLine("Basestation: unknown object type");
                        break;
                }
            }
        }

        private void ReceivedHeartBeat(HeartBeat hrtBtMsg)
        {
            //update timer for corresponding peer

            bool fromThisPeer = string.Equals(hrtBtMsg.senderIpAddress, this.myHeartBeat.senderIpAddress);
            bool fromExistingPeer = IsIpAddressKnown(hrtBtMsg.senderIpAddress);
            if (!fromThisPeer && !fromExistingPeer)
            {
                //new peer
                Peer latestPeer = new Peer(hrtBtMsg, timeOutMilliSec);
                latestPeer.aliveTimeout.Elapsed += AliveTimeoutElapsed;

                knownPeers.Add(latestPeer);

                //send out a broadcast to all subscribers
                PeerChanged?.Invoke(this, new PeerUpdateEventArgs(knownPeers));
            }
        }

        private void AliveTimeoutElapsed(object sender, ElapsedEventArgs e)
        {
            PeerChanged?.Invoke(this, new PeerUpdateEventArgs(knownPeers));
        }

        private void RecievedKeyStroke(KeyStrokeMsg kyStrkMsg)
        {
            KeyStrokeReceived?.Invoke(this, new KeyStrokeEventArgs(kyStrkMsg));
        }



        //non-blocking
        private async void SendBroadcastAsync(string message)
        {
            this.udpConnection.EnableBroadcast = true;
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, this.portNum);
            byte[] datagram = Encoding.ASCII.GetBytes(message);

            await udpConnection.SendAsync(datagram, datagram.Length, endPoint);
        }

        //non-blocking
        private async void SendMessageAsync(string ipAddress, string message)
        {
            IPAddress ipAddressObj = IPAddress.Parse(ipAddress);
            IPEndPoint endPoint = new IPEndPoint(ipAddressObj, this.portNum);
            byte[] datagram = Encoding.ASCII.GetBytes(message);

            await udpConnection.SendAsync(datagram, datagram.Length, endPoint);
        }

        public void SendKeyStrokeToPeers(string message)
        {
            foreach(Peer peer in knownPeers)
            {
                //only send keystroke to peers that will accept the keystroke
                if( peer.lastHeartBeat.acceptKeyStrokes)
                {
                    string peerIp = peer.lastHeartBeat.senderIpAddress;
                    this.SendMessageAsync(peerIp, message);
                }          
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