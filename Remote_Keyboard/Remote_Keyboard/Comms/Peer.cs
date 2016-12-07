using System;
using System.Collections.Generic;
using System.Text;

namespace Remote_Keyboard.Comms
{
    class Peer
    {
        //IP address of the this peer
        string thisPeerIPAddress;
        //whether this peer will accept keystrokes
        bool acceptSendKeyStrokes;

        Peer(string mAddressIP, bool mSendKeyStorkes = true)
        {
            this.thisPeerIPAddress = mAddressIP;
            this.acceptSendKeyStrokes = mSendKeyStorkes;
        }
    }
}
