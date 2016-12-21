using System;
using System.Collections.Generic;
using System.Text;

using System.Timers; //for client timeout

namespace Remote_Keyboard.Comms
{
    public class Peer
    {
        public HeartBeat lastHeartBeat;

        //when timer expires the connect to the client is assumed to be lost
        public Timer aliveTimeout;

        //every peer has its own connection
        public PeerConnection peerConnection;

        public bool activePeer = true;

        //constructor
        public Peer( HeartBeat mLastHeartBeat, double timeOutTimeMillSec )
        {
            this.lastHeartBeat = mLastHeartBeat;

            string peerIpAddress = mLastHeartBeat.senderIpAddress;

            this.peerConnection = new PeerConnection(peerIpAddress);

            this.aliveTimeout = new Timer();
            this.aliveTimeout.AutoReset = false;
            this.aliveTimeout.Interval = timeOutTimeMillSec;
            this.aliveTimeout.Start();
        }
    }
}
