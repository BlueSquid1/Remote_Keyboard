#if !WINDOWS_UWP

using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets; //for UdpClient
using System.Net; //for IPEndPoint


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
            this.portNum = portNum;
            this.udpConnection = new UdpClient(portNum);
        }

        //deconstructor
        ~BaseStation()
        {
            this.udpConnection.Close();
        }

        //non-blocking
        public async void StartingListeningAsync()
        {
            while (true)
            {
                var result = await this.udpConnection.ReceiveAsync();
                var message = Encoding.ASCII.GetString(result.Buffer);
                Console.WriteLine(message);
            }
        }

        //non-blocking
        public async void BroadcastSendAsync(string message)
        {
            udpConnection.EnableBroadcast = true;
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, this.portNum);
            byte[] datagram = Encoding.ASCII.GetBytes(message);

            await udpConnection.SendAsync(datagram, datagram.Length, endPoint);
        }
    }
}

#endif