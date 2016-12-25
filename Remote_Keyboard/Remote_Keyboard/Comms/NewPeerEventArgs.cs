using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Remote_Keyboard.Comms
{
    public class NewPeerEventArgs : EventArgs
    {
        public readonly TcpClient tcpClient;

        //constructor
        public NewPeerEventArgs(TcpClient mTcpClient)
        {
            this.tcpClient = mTcpClient;
        }
    }
}
