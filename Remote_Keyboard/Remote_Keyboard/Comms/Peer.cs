using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Remote_Keyboard.Comms
{
    class Peer
    {
        //IP address of the this peer
        public IPAddress thisPeerIPAddress { get; }
        //whether this peer will accept keystrokes
        public bool acceptSendKeyStrokes { get; set;}

        public Peer(IPAddress mAddressIP, bool mSendKeyStorkes = true)
        {
            this.thisPeerIPAddress = mAddressIP;
            this.acceptSendKeyStrokes = mSendKeyStorkes;
        }
    }
}
