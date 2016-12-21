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
        //TODO - I think this might be static?
        private TcpListener tcpListener;

        private static readonly int portNum = 10011;
        private string ipAddress;

        //static constructor
        static PeerConnection()
        {
            udpClient = new UdpClient(portNum);
            udpClient.EnableBroadcast = true;
            StartListeningFromUDPAsync();
        }

        //constructor
        public PeerConnection(string ipAddress)
        {
            this.ipAddress = ipAddress;
            //tcpListener = new TcpListener(IPAddress.Parse(ipAddress), portNum);
            tcpListener = new TcpListener(IPAddress.Any, portNum);
            StartListeningForTCP();
            //tcpClient = new TcpClient(ipAddress, portNum);
        }

        //deconstructor
        ~PeerConnection()
        {
            tcpListener.Stop();
        }

        //non-blocking
        public static async void SendBroadcastAsync(string message)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, portNum);
            byte[] datagram = Encoding.ASCII.GetBytes(message);

            await udpClient.SendAsync(datagram, datagram.Length, endPoint);
        }

        //non-blocking
        private static async void StartListeningFromUDPAsync()
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
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(ipAddress, portNum);


            NetworkStream netStream = tcpClient.GetStream();
            StreamWriter sw = new StreamWriter(netStream);
            await sw.WriteAsync(message);
            sw.Flush();

            netStream.Close();
            tcpClient.Close();
        }

        //non-blocking
        private async void StartListeningForTCP()
        {
            tcpListener.Start();

            int count = 0;
            while (true)
            {
                
                TcpClient client = await tcpListener.AcceptTcpClientAsync();
                
                NetworkStream netStream = client.GetStream();
                //BinaryReader reader = new BinaryReader(netStream);

                byte[] buffer = new byte[client.ReceiveBufferSize];
                netStream.Read(buffer, 0, client.ReceiveBufferSize);

                string message = Encoding.ASCII.GetString(buffer);
                MsgReceived?.Invoke(null, new MsgReceivedEventArgs(message));
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
