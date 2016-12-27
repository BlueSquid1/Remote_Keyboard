using Remote_Keyboard.Events;
using System;
using System.Collections.Generic;
using System.Text;
using Remote_Keyboard.Comms;
using System.ComponentModel;

namespace Remote_Keyboard.Common
{
    class AirKeyboard
    {
        private EventManager eventManager;
        private BaseStation baseStation;

        private List<string> keysHeldDown;

        public event EventHandler<PeerUpdateEventArgs> PeerChanged;
        public event EventHandler<KeyLogUpdateEventArgs> KeyLogUpdate;

        //constructor
        public AirKeyboard(EventManager evntManager, ISynchronizeInvoke timerSync = null)
        {
            keysHeldDown = new List<string>();
            this.eventManager = evntManager;
            this.baseStation = new BaseStation(timerSync);
            baseStation.PeerChanged += BaseStationPeerChanged;
            baseStation.KeyStrokeReceived += BaseStationKeyStrokeReceived;
        }

        private void BaseStationKeyStrokeReceived(object sender, KeyStrokeEventArgs e)
        {
            string sdlValue = e.keyStrkMsg.keyStrokeSDL;
            bool isPressed = e.keyStrkMsg.isPressed;
            LogKey(sdlValue, isPressed);
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

            //log which keys have been pressed
            LogKey(sdlValue, isPressed);

            string message = XMLParser.SerializeObject(msg);
            baseStation.SendMessageToAllPeers(message);
        }

        public void SendKeyList(List<ushort> nativeKeys, bool isPressed)
        {
            foreach(ushort keyValue in nativeKeys)
            {
                this.SendKey(keyValue, isPressed);
            }
        }

        /*
        public void SendClipBoard(string clipboardMsg)
        {

        }
        */


        private void LogKey(string sdlValue, bool isPressed)
        {
            if (isPressed)
            {
                //check if key has already been added
                this.AddUniqueKey(sdlValue);

                //broadcast update
                KeyLogUpdate?.Invoke(this, new KeyLogUpdateEventArgs(keysHeldDown));
            }
            else
            {
                keysHeldDown.Remove(sdlValue);
                //broadcast update
                KeyLogUpdate?.Invoke(this, new KeyLogUpdateEventArgs(keysHeldDown));
            }
        }

        private void AddUniqueKey(string sdlValue)
        {
            //check if key is already in keysHeldDown list
            foreach(string heldDownKey in keysHeldDown)
            {
                if(heldDownKey == sdlValue)
                {
                    //key already in list
                    return;
                }
            }
            //add the key
            keysHeldDown.Add(sdlValue);
        }
    }
}
