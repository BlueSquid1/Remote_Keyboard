using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Remote_Keyboard.Comms
{
    [Serializable]
    public enum OSValue
    {
        Windows10 = 0,
        OSX = 1,
        Linux = 2,
        Android = 3,
        iOS = 4
    }

    public class PeerMsg
    {
        public string thisPeerIPAddress { get; set; }
        public string targetIPAddress { get; set; }
        public OSValue? thisOS { get; set; }

        public bool? acceptSendKeyStrokes { get; set; }
        public string keyStrokeSDL { get; set; }
        public bool? isPressed { get; set; }
    }
}
