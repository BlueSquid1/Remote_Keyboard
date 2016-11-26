using System;
using System.Collections.Generic;
using System.Text;

namespace Remote_Keyboard
{
    public abstract class EventManager
    {
        //Hashtable sdlKeyToNativeKey = new Hashtable();
        //Hashtable nativeKeyToSdlKey = new Hashtable();

        protected SortedDictionary<string, ushort> sdlKeyToNativeKey = new SortedDictionary<string, ushort>();


        public abstract void TriggerKeyPress(ushort scanCode, bool isPressed);

        public abstract ushort ScanCodeFromVirtualKey(ushort virtualKeyCode);

        public abstract ushort VirtualKeyFromScanCode(ushort scanCode);
        
        public string test()
        {
            return "testing";
        }
    }
}
