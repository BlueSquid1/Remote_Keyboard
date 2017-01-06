using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace Remote_Keyboard.Comms
{
    public class Listener
    {
        //static methods and variables don't used a specific IP address
        public event EventHandler<MsgReceivedEventArgs> MsgReceived;

        private  UdpClient udpClient;

        //constructor
        public Listener(UdpClient mUdpClient)
        {
            this.udpClient = mUdpClient;
        }

        //non-blocking
        private static async void StartListeningFromUDPAsync()
        {
            udpClient.EnableBroadcast = true;

            while (true)
            {
                UdpReceiveResult receivedUDP = await udpClient.ReceiveAsync();
                //received message
                string message = Encoding.UTF8.GetString(receivedUDP.Buffer);
                MsgReceived?.Invoke(null, new MsgReceivedEventArgs(message));
            }
        }

        //non-blocking
        public static async void SendBrdcstUDPAsync(string message)
        {
            byte[] datagram = Encoding.UTF8.GetBytes(message);
            await udpClient.SendAsync(datagram, datagram.Length, IPAddress.Broadcast.ToString(), portNum);
        }


        public async void SendMsgToPeerUDPAsync(string message)
        {
            byte[] datagram = Encoding.UTF8.GetBytes(message);
            await udpClient.SendAsync(datagram, datagram.Length, this.peerIpAddress, portNum);
        }
    }
}
