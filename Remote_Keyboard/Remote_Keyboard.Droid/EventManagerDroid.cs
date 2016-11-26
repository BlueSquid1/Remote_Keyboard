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
    class EventManagerDroid : EventManager
    {
        //constructor
        public EventManagerDroid()
        {
            this.PopulateKeyMapping();
        }

        private void PopulateKeyMapping()
        {
            XMLParser.PopulateKeyMapFromXML(ref sdlKeyToNativeKey);
        }

        public override ushort ScanCodeFromVirtualKey(ushort virtualKeyCode)
        {
            throw new NotImplementedException();
        }

        public override void TriggerKeyPress(ushort scanCode, bool isPressed)
        {
            throw new NotImplementedException();
        }

        public override ushort VirtualKeyFromScanCode(ushort scanCode)
        {
            throw new NotImplementedException();
        }
    }
}