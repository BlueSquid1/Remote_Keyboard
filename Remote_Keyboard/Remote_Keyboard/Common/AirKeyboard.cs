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
            baseStation.PeerChanged += BaseStationPeerChanged;
            baseStation.KeyStrokeReceived += BaseStationKeyStrokeReceived;
        }

        private void BaseStationKeyStrokeReceived(object sender, KeyStrokeEventArgs e)
        {
            string sdlValue = e.keyStrkMsg.keyStrokeSDL;
            bool isPressed = e.keyStrkMsg.isPressed;
            eventManager.TriggerKeyPress(e.keyStrkMsg.keyStrokeSDL, isPressed);
        }

        private void BaseStationPeerChanged(object sender, PeerUpdateEventArgs e)
        {
            this.PeerChanged?.Invoke(sender, e);
        }



        //connect with native keyboard
        public void SendKey(ushort nativeKey, bool isPressed)
        {
            //convert to an SDL value
            string sdlValue = eventManager.NativeKeyToSdl(nativeKey);

            KeyStrokeMsg msg = new KeyStrokeMsg {
                keyStrokeSDL = sdlValue,
                isPressed = isPressed,
            };
            string message = XMLParser.SerializeObject(msg);
            baseStation.SendKeyStrokeToPeers(message);

            Console.WriteLine(message);
        }
    }
}
