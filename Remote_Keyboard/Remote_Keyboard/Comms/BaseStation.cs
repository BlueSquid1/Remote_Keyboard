#if !WINDOWS_UWP

using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets; //for UdpClient
using System.Net; //for IPEndPoint
using System.Timers; //for broadcast events


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


namespace Remote_Keyboard
{
    //singleton class
    //one BaseStation is used to send and retrieve data
    //singleton
    class BaseStation
    {
        private static BaseStation instance = null;

        private UdpClient udpConnection;
        private int portNum;
        //public string TargetIP { get; set; }
        private Timer brdcstTmr;
        private string brdcstMsg;

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
        private BaseStation( int portNum )
        {
            int timeIntrvlMilliSec = 1000;
            this.portNum = portNum;
            this.udpConnection = new UdpClient(portNum);
            StartBroadcasting(timeIntrvlMilliSec);
            StartingListeningAsync();
        }

        //deconstructor
        ~BaseStation()
        {
            this.udpConnection.Close();
        }

        private void StartBroadcasting(int timeIntrvlMilliSec)
        {
            //populate broadcast message
            this.brdcstMsg = XMLParser.SerializeKeyPress("is anyone there?");
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
                UdpReceiveResult result = await this.udpConnection.ReceiveAsync();
                string message = Encoding.ASCII.GetString(result.Buffer);
                Console.WriteLine("Received =" + message);
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
        public async void SendMessageAsync(string targetIP, string message)
        {
            IPAddress ipAdress = IPAddress.Parse(targetIP);
            IPEndPoint endPoint = new IPEndPoint(ipAdress, this.portNum);
            byte[] datagram = Encoding.ASCII.GetBytes(message);

            await udpConnection.SendAsync(datagram, datagram.Length, endPoint);
        }
    }
}

#endif