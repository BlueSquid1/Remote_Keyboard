using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Remote_Keyboard.Droid
{
    class EventManagerDroid : IEventManager
    {
        //Hashtable qtKeyToNativeKey = new Hashtable();
        //Hashtable nativeKeyToQtKey = new Hashtable();


        public ushort ScanCodeFromVirtualKey(ushort virtualKeyCode)
        {
            throw new NotImplementedException();
        }

        public void TriggerKeyPress(ushort scanCode, bool isPressed)
        {
            throw new NotImplementedException();
        }

        public ushort VirtualKeyFromScanCode(ushort scanCode)
        {
            throw new NotImplementedException();
        }
    }
}