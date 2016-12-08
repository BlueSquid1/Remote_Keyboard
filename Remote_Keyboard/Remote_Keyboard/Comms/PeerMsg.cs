using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Remote_Keyboard.Comms
{
    [Serializable]
    public class PeerMsg
    {
        public string thisPeerIPAddress { get; set; }
        public string targetIPAddress { get; set; }
        public bool? acceptSendKeyStrokes { get; set; } //= true;
        public string keyStrokeSDL { get; set; }
        public bool? isPressed { get; set; }
    }
}
