using System;
using System.Collections.Generic;
using System.Text;

namespace Remote_Keyboard.Comms
{
    class PeerUpdateEventArgs : System.EventArgs
    {
        public readonly List<Peer> peers;

        //constructor
        public PeerUpdateEventArgs(List<Peer> mPeers)
        {
            this.peers = mPeers;
        }
    }
}
