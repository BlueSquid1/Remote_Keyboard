using Remote_Keyboard.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Remote_Keyboard.Comms
{
    public class HeartBeat : IMessage
    {
        public MessageType msgType { get; set; } = MessageType.HeartBeat;

        public string senderIpAddress { get; set; }
        public bool acceptKeyStrokes { get; set; }
        public bool acceptCopySync { get; set; }
        public OSValue platform{ get; set; }
    }
}
