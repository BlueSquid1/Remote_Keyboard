using Remote_Keyboard.Events;
using System;
using System.Collections.Generic;
using System.Text;
using Remote_Keyboard.Comms;

namespace Remote_Keyboard.Common
{
    class AirKeyboard
    {
        private EventManager eventManager;
        private BaseStation baseStation;

        //constructor
        public AirKeyboard(EventManager evntManager)
        {
            int portNum = 10010;
            this.eventManager = evntManager;
            this.baseStation = BaseStation.GetInstance(portNum);
        }

        public void SendKey(ushort nativeKey, bool isPressed)
        {
            string sdlValue = eventManager.NativeKeyToSdl(nativeKey);

            KeyMessage msg = new KeyMessage { sdlKeyValue = sdlValue, isPressed = true };
            string message = XMLParser.SerializeKeyPress(msg);
            //baseStation.SendMessageAsync(message);
            Console.WriteLine(msg.sdlKeyValue);
        }
    }
}
