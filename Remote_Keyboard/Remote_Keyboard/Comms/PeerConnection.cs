using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace Remote_Keyboard.Comms
{
    public class PeerConnection
    {
        //static methods and variables don't used a specific IP address
        public static event EventHandler<MsgReceivedEventArgs> MsgReceived;
        public static event EventHandler<NewPeerEventArgs> NewPeerEvent;

        private static readonly int portNum = 8762;
        public string peerIpAddress { get; set; }

        private static UdpClient udpClient;

        private TcpListener tcpListener;
        private TcpClient tcpClientRead;
        private TcpClient tcpClientWrite;
        private NetworkStream netStreamRead;
        private NetworkStream netStreamWrite;

        //static constructor
        static PeerConnection()
        {
            //start the TCP and UDP servers
            udpClient = new UdpClient(portNum);

            StartListeningFromUDPAsync();
        }

        //constructor
        public PeerConnection(string ipAddress)
        {
            this.peerIpAddress = ipAddress;
            this.tcpClientWrite = new TcpClient();
            this.tcpListener = new TcpListener(IPAddress.Any, portNum);

            ListenForPeerTCP();
            EstablishConnectionWithPeerTCP();
            
            //block until read and write stream are avaliable
            while(netStreamWrite == null || netStreamRead == null)
            {

            }
            StartListeningFromTCPAsync();
        }

        private async void ListenForPeerTCP()
        {
            tcpListener.Start();

            this.tcpClientRead = await this.tcpListener.AcceptTcpClientAsync();
            this.netStreamRead = this.tcpClientRead.GetStream();
        }

        private async void EstablishConnectionWithPeerTCP()
        {
            await this.tcpClientWrite.ConnectAsync(peerIpAddress, portNum);
            this.netStreamWrite = tcpClientWrite.GetStream();
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

        public async void SendMsgToPeerTCP(string message)
        {
            Byte[] buffer = Encoding.UTF8.GetBytes(message);
            netStreamWrite.Write(buffer, 0, buffer.Length);
            await netStreamWrite.FlushAsync();
        }

        private async void StartListeningFromTCPAsync()
        {
            Byte[] buffer = new Byte[1];
            await netStreamRead.ReadAsync(buffer, 0, buffer.Length);
            string msg = Encoding.UTF8.GetString(buffer);
            Console.WriteLine(msg);
        }

        /*

        public async void SendMsgToPeerTCP(string message)
        {
			Byte[] buffer = Encoding.UTF8.GetBytes(message);

			tcpClient.WriteStream.Write(buffer, 0, buffer.Length);

			await tcpClient.WriteStream.FlushAsync();

			// wait a little before sending the next chunck of data
			await Task.Delay(TimeSpan.FromMilliseconds(500));
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
        */
    }
}
