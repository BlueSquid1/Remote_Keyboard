using Remote_Keyboard.Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Remote_Keyboard.Comms.Messages
{
    public class KeyStrokeMsg : IMessage
    {
        public MessageType msgType { get; set; } = MessageType.KeyStroke;

        public string sourceIPAddress { get; set; }
        public string targetIPAddress { get; set; }

        public string keyStrokeSDL { get; set; }
        public bool isPressed { get; set; }
    }
}
