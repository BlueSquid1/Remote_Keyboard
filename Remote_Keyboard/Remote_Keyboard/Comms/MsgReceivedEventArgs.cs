using System;
using System.Collections.Generic;
using System.Text;

namespace Remote_Keyboard.Comms
{
    public class MsgReceivedEventArgs : System.EventArgs
    {
        public readonly string message;

        //constructor
        public MsgReceivedEventArgs(string msg)
        {
            this.message = msg;
        }
    }
}
