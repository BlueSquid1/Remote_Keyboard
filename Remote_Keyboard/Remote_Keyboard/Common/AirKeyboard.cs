﻿using Remote_Keyboard.Events;
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

        private List<string> keysHeldDown;

        public event EventHandler<PeerUpdateEventArgs> PeerChanged;
        public event EventHandler<KeyLogUpdateEventArgs> KeyLogUpdate;

        //constructor
        public AirKeyboard(EventManager evntManager)
        {
            int portNum = 10010;
            keysHeldDown = new List<string>();
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

            //log which keys have been pressed
            LogKey(sdlValue, isPressed);

            string message = XMLParser.SerializeObject(msg);
            baseStation.SendKeyStrokeToPeers(message);
        }


        private void LogKey(string sdlValue, bool isPressed)
        {
            if (isPressed)
            {
                //check if key has already been added
                this.AddUniqueKey(sdlValue);
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

            //broadcast update
            KeyLogUpdate?.Invoke(this, new KeyLogUpdateEventArgs(keysHeldDown));
        }
    }
}