using System;
using System.Collections.Generic;
using System.Text;

namespace Remote_Keyboard.Comms
{
    class PeerUpdateEventArgs : System.EventArgs
    {
        public readonly List<PeerMsg> peers;

        //constructor
        public PeerUpdateEventArgs(List<PeerMsg> mPeers)
        {
            this.peers = mPeers;
        }
    }
}
