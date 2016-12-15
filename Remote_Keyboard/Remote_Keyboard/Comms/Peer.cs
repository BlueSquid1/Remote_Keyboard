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

        //constructor
        public Peer( HeartBeat mLastHeartBeat, double timeOutTimeMillSec)
        {
            this.lastHeartBeat = mLastHeartBeat;

            this.aliveTimeout = new Timer();
            this.aliveTimeout.Interval = timeOutTimeMillSec;
            this.aliveTimeout.Start();
        }
    }
}
