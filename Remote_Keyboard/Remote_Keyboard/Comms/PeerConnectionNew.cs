using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using Sockets.Plugin;

namespace Remote_Keyboard.Comms
{
    public class PeerConnectionNew
    {
        public static event EventHandler<MsgReceivedEventArgs> MsgReceived;

        private static UdpSocketReceiver udpListener;
        private static UdpSocketClient udpClient;

        //TODO - I think this might be static?
        private TcpListener tcpListener;

        private static readonly int portNum = 8762;
        private string ipAddress;

        private static EndPoint ReceiveIP;
        private static Socket socket;

        //static constructor
        static PeerConnectionNew()
        {

            StartListeningFromUDPAsync();

            udpClient = new UdpSocketClient();
        }

        //constructor
        public PeerConnectionNew(string ipAddress)
        {
            this.ipAddress = ipAddress;
            //tcpListener = new TcpListener(IPAddress.Parse(ipAddress), portNum);
            tcpListener = new TcpListener(IPAddress.Any, portNum);
            StartListeningForTCP();
            //tcpClient = new TcpClient(ipAddress, portNum);
        }

        //deconstructor
        ~PeerConnectionNew()
        {
            udpListener.StopListeningAsync();

            tcpListener.Stop();
        }

        //non-blocking
        private static void StartListeningFromUDPAsync()
        {
            udpListener = new UdpSocketReceiver();
            udpListener.MessageReceived += UdpListener_MessageReceived;
            udpListener.StartListeningAsync(portNum);
        }

        private static void UdpListener_MessageReceived(object sender, Sockets.Plugin.Abstractions.UdpSocketMessageReceivedEventArgs e)
        {
            //read received message
            string message = Encoding.UTF8.GetString(e.ByteData, 0, e.ByteData.Length);
            MsgReceivedEventArgs temp = new MsgReceivedEventArgs(message);
            MsgReceived?.Invoke(null, temp);
        }


        //non-blocking
        public static async void SendBrdcstUDPAsync(string message)
        {
            //IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, portNum);
            byte[] datagram = Encoding.UTF8.GetBytes(message);

            await udpClient.SendToAsync(datagram, IPAddress.Broadcast.ToString(), portNum);
        }

        public async void SendMsgToPeerUDP(string message)
        {
            //IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, portNum);
            byte[] datagram = Encoding.UTF8.GetBytes(message);

            await udpClient.SendToAsync(datagram, ipAddress, portNum);
        }

        public async void SendMsgToPeerTCP(string message)
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
