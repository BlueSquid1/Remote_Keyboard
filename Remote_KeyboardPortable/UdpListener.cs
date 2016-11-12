using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets; //for UdpClient
using System.Net; //for IPEndPoint


namespace Remote_KeyboardPortable
{
    class UdpListener
    {
        private UdpClient udpClient;
        private int portNum;

        //constructor
        public UdpListener( int portNum )
        {
            this.portNum = portNum;
            this.udpClient = new UdpClient(portNum);
        }

        //deconstructor
        ~UdpListener()
        {
            this.udpClient.Close();
        }

        //async means run concurrently
        public async void StartingListening()
        {
            while (true)
            {
                var result = await this.udpClient.ReceiveAsync();
                var message = Encoding.ASCII.GetString(result.Buffer);
                Console.WriteLine(message);
            }
        }

        public async void BroadcastSend(string message)
        {
            udpClient.EnableBroadcast = true;
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, 1000);
            byte[] datagram = Encoding.ASCII.GetBytes(message);

            await udpClient.SendAsync(datagram, datagram.Length, endPoint);
        }
    }
}