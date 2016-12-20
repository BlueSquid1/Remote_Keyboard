using System;
using System.Collections.Generic;
using System.Text;

namespace Remote_Keyboard.Comms
{
    [Serializable]
    public enum MessageType
    {
        HeartBeat = 0,
        KeyStroke = 1
    }

    public interface IMessage
    {
        MessageType msgType { get; set; }
    }
}