using System;
using System.Collections.Generic;
using System.Text;

namespace Remote_Keyboard.Comms
{
    class KeyStrokeEventArgs : System.EventArgs
    {
        public readonly KeyStrokeMsg keyStrkMsg;

        //constructor
        public KeyStrokeEventArgs(KeyStrokeMsg mKeyStrkMsg)
        {
            this.keyStrkMsg = mKeyStrkMsg;
        }
    }
}
