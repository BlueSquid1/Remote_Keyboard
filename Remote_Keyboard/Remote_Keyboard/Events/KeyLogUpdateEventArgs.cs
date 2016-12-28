using System;
using System.Collections.Generic;
using System.Text;

namespace Remote_Keyboard.Events
{
    class KeyLogUpdateEventArgs : System.EventArgs
    {
        public List<string> keysHeldDown { get; }

        //constructor
        public KeyLogUpdateEventArgs( List<string> mKeysHeldDown)
        {
            this.keysHeldDown = mKeysHeldDown;
        }
    }
}
