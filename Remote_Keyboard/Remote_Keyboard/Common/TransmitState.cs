using Remote_Keyboard.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Remote_Keyboard.Common
{
    class TransmitState
    {
        private EventManager eventManager;
        private BaseStation baseStation;

        public TransmitState(EventManager mEventManager, BaseStation mBaseStation)
        {
            //int portNum = 10000;
            this.eventManager = mEventManager;
            this.baseStation = mBaseStation;
            //this.baseStation.TargetIP = "192.168.1.100";
        }

        public void SendKey(ushort nativeKey, bool isPressed)
        {
            string sdlValue = eventManager.NativeKeyToSdl(nativeKey);

            KeyMessage msg = new KeyMessage { sdlKeyValue = sdlValue, isPressed = true };
            string message = XMLParser.SerializeKeyPress(msg);
            baseStation.SendMessageAsync(message);
            Console.WriteLine(msg.sdlKeyValue);
        }
    }
}
