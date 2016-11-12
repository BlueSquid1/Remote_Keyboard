using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;


namespace Remote_Keyboard
{
    class UdpListener
    {
        private UdpClient udpListener;

        //constructor
        public UdpListener( int portNum )
        {
            this.udpListener = new UdpClient(portNum);
        }

        //async means run concurrently
        public async void StartingListening()
        {
            while (true)
            {
                var result = await this.udpListener.ReceiveAsync();
                var message = Encoding.ASCII.GetString(result.Buffer);
                Console.WriteLine(message);
            }
        }
    }
}