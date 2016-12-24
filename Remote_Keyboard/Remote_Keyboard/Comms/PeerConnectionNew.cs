using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using Sockets.Plugin;
using Sockets.Plugin.Abstractions;
using System.Threading.Tasks;

namespace Remote_Keyboard.Comms
{
    public class PeerConnectionNew
    {
		//static methods and variables don't used a specific IP address
        public static event EventHandler<MsgReceivedEventArgs> MsgReceived;

		private static readonly int portNum = 8762;

        private static UdpSocketReceiver udpListener;
        private static UdpSocketClient udpClient;
		private static TcpSocketListener tcpListener;

		//non-static variables and methods are specific to a given IP address
		private TcpSocketClient tcpClient;

		public string ipAddress { get; set; }

		//static constructor
		static PeerConnectionNew()
        {
			udpListener = new UdpSocketReceiver();
			udpClient = new UdpSocketClient();
			tcpListener = new TcpSocketListener();

            StartListeningFromUDPAsync();
			StartListeningForTCP();
        }

        //constructor
        public PeerConnectionNew(string ipAddress)
        {
            this.ipAddress = ipAddress;
			this.tcpClient = new TcpSocketClient();

			this.ConnectToClientTCP();
		}

		//deconstructor
		~PeerConnectionNew()
		{
			tcpClient.DisconnectAsync();
		}

		//non-blocking
		private static void StartListeningFromUDPAsync()
		{
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

		public async void ConnectToClientTCP()
		{
			await tcpClient.ConnectAsync(this.ipAddress, portNum);
		}

        public async void SendMsgToPeerTCP(string message)
        {
			Byte[] buffer = Encoding.UTF8.GetBytes(message);

			tcpClient.WriteStream.Write(buffer, 0, buffer.Length);

			await tcpClient.WriteStream.FlushAsync();

			// wait a little before sending the next chunck of data
			await Task.Delay(TimeSpan.FromMilliseconds(500));
        }

		//non-blocking
		private static async void StartListeningForTCP()
		{
			tcpListener.ConnectionReceived += TcpIncomingMsg;
			await tcpListener.StartListeningAsync(portNum);
		}

		private static void TcpIncomingMsg(object sender, TcpSocketListenerConnectEventArgs e)
		{
			ITcpSocketClient client = e.SocketClient;
			Stream tcpStream = client.ReadStream;
			byte[] buffer = new byte[tcpStream.Length];
			//tcpStream.Read(
			int numBytesRead = tcpStream.Read(buffer, 0, (int)tcpStream.Length);
			if (numBytesRead <= 0)
			{
				//empty buffer
				return;
			}
			string message = Encoding.UTF8.GetString(buffer);
			MsgReceived?.Invoke(null, new MsgReceivedEventArgs(message));
		}

		public static void StopListening()
		{
			udpListener.StopListeningAsync();
			tcpListener.StopListeningAsync();
		}
    }
}
