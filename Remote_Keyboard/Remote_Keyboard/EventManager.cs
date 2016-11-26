using System;
using System.Collections.Generic;
using System.Text;

namespace Remote_Keyboard
{
    public abstract class EventManager
    {
        protected Dictionary<string, ushort> sdlKeyToNativeKey = new Dictionary<string, ushort>();
        protected Dictionary<ushort, string> nativeKeyToSdlKey = new Dictionary<ushort, string>();

        //constructor
        public EventManager()
        {
            
        }

        public abstract ushort SdlKeyToNativeKey(string sdlKey);

        public abstract string NativeKeytoSdlKey(ushort scanCode);

        public abstract void TriggerKeyPress(string sdlKey, bool isPressed);
    }
}
