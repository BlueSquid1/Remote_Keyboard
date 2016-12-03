using Remote_Keyboard.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Remote_Keyboard.Common
{
    class RemoteControl
    {
        private EventManager eventManager;
        private BaseStation baseStation;

        public RemoteControl(EventManager mEventManager)
        {
            int portNum = 10000;
            this.eventManager = mEventManager;
        }

        public void SendKey(ushort nativeKey, bool isPressed)
        {
            string sdlValue = eventManager.NativeKeyToSdl(nativeKey);
            string message = XMLParser.ParseKeyPress(sdlValue, isPressed);
            //baseStation.SendMessageAsync(message);
            Console.WriteLine(message);
        }
    }
}
