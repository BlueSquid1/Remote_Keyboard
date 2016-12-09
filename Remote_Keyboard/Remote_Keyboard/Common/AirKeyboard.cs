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

        public event EventHandler<PeerUpdateEventArgs> PeerChanged;


        //constructor
        public AirKeyboard(EventManager evntManager)
        {
            int portNum = 10010;
            this.eventManager = evntManager;
            this.baseStation = BaseStation.GetInstance(portNum);
            baseStation.PeerChanged += BaseStation_PeerChanged;

        }

        private void BaseStation_PeerChanged(object sender, PeerUpdateEventArgs e)
        {
            this.PeerChanged?.Invoke(sender, e);
        }

        public void SendKey(ushort nativeKey, bool isPressed)
        {
            string sdlValue = eventManager.NativeKeyToSdl(nativeKey);

            PeerMsg msg = new PeerMsg { keyStrokeSDL = sdlValue, isPressed = true };
            string message = XMLParser.SerializeObject(msg);
            PeerMsg temp = XMLParser.DeserializeObject<PeerMsg>(message);

            //send message to all connected peers
            //baseStation.SendMessageAsync(message);
            Console.WriteLine(message);
        }
    }
}
