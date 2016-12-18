using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace Remote_Keyboard.Comms
{
    public class PeerConnection
    {
        public static event EventHandler<MsgReceivedEventArgs> MsgReceived;

        private static UdpClient udpClient;
        private TcpClient tcpClient;
        //TODO - I think this might be static?
        private TcpListener tcpListener;

        private static readonly int portNum = 10011;
        private string ipAddress;

        //static constructor
        static PeerConnection()
        {
            udpClient = new UdpClient(portNum);
            udpClient.EnableBroadcast = true;
            StartingListeningAsync();
        }

        //constructor
        public PeerConnection(string ipAddress)
        {
            this.ipAddress = ipAddress;
            //tcpListener = new TcpListener(IPAddress.Parse(ipAddress), portNum);
            tcpListener = new TcpListener(IPAddress.Any, portNum);
            StartListening();
            //tcpClient = new TcpClient(ipAddress, portNum);
        }

        //non-blocking
        public static async void SendBroadcastAsync(string message)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, portNum);
            byte[] datagram = Encoding.ASCII.GetBytes(message);

            await udpClient.SendAsync(datagram, datagram.Length, endPoint);
        }

        //non-blocking
        private static async void StartingListeningAsync()
        {
            while (true)
            {
                //read received message
                UdpReceiveResult result = await udpClient.ReceiveAsync();
                string message = Encoding.ASCII.GetString(result.Buffer);
                MsgReceived?.Invoke(null, new MsgReceivedEventArgs(message));
            }
        }

        public async void SendMessageToPeer(string message)
        {
            //TODO
            tcpClient = new TcpClient();
            tcpClient.Connect(ipAddress, portNum);


            NetworkStream netStream = tcpClient.GetStream();
            StreamWriter sw = new StreamWriter(netStream);
            sw.Write((string)message);
            //sw.Write((string)messa
            sw.Flush();

            netStream.Close();
            tcpClient.Close();
        }

        //non-blocking
        private async void StartListening()
        {
            tcpListener.Start();
            
            while (true)
            {
                
                TcpClient client = await tcpListener.AcceptTcpClientAsync();
                /*
                NetworkStream netStream = client.GetStream();
                BinaryReader reader = new BinaryReader(netStream);
                string message = reader.ReadString();
                Console.WriteLine(message);
                */
            }
            
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

    }
}
