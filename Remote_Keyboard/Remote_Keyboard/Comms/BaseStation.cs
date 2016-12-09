using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets; //for UdpClient
using System.Net; //for IPEndPoint
using System.Timers; //for broadcast events
using System.Linq;


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

        //stores other peers on the network
        private List<PeerMsg> peers;
        private PeerMsg thisPeer;

        //peer change event
        public event EventHandler<PeerUpdateEventArgs> PeerChanged;

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
            this.peers = new List<PeerMsg>();
            this.portNum = mPortNum;
            this.udpConnection = new UdpClient(portNum);
            this.thisPeer = new PeerMsg { thisPeerIPAddress = this.GetLocalIPAddress().ToString(), acceptSendKeyStrokes = true, thisOS = OSValue.Windows10 };

        }

        private void StartBroadcasting(int timeIntrvlMilliSec)
        {
            //populate broadcast message
            this.brdcstMsg = XMLParser.SerializeObject(this.thisPeer);
            PeerMsg temp = XMLParser.DeserializeObject<PeerMsg>(brdcstMsg);
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
                //IPAddress senderAddress = result.RemoteEndPoint.Address;
                PeerMsg peerMsgRciv = XMLParser.DeserializeObject<PeerMsg>(message);

                bool fromThisPeer = string.Equals(peerMsgRciv.thisPeerIPAddress, this.thisPeer.thisPeerIPAddress);
                bool fromExistingPeer = IsIpAddressKnown(peerMsgRciv.thisPeerIPAddress);
                if (!fromThisPeer && !fromExistingPeer)
                {
                    peers.Add(peerMsgRciv);

                    //send out a broadcast to all subscribers
                    PeerChanged?.Invoke(this, new PeerUpdateEventArgs(peers));
                }
            }
        }

        //non-blocking
        public async void SendBroadcastAsync(string message)
        {
            this.udpConnection.EnableBroadcast = true;
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, this.portNum);
            byte[] datagram = Encoding.ASCII.GetBytes(message);

            await udpConnection.SendAsync(datagram, datagram.Length, endPoint);
        }

        //non-blocking
        public async void SendMessageAsync(IPAddress ipAddress, string message)
        {
            IPEndPoint endPoint = new IPEndPoint(ipAddress, this.portNum);
            byte[] datagram = Encoding.ASCII.GetBytes(message);

            await udpConnection.SendAsync(datagram, datagram.Length, endPoint);
        }

        private bool IsIpAddressKnown(String testIp)
        {
            foreach(PeerMsg curPeer in peers)
            {
                if(string.Equals(curPeer.thisPeerIPAddress, testIp))
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