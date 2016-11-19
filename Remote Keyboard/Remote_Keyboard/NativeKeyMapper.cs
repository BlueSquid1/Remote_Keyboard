using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;

namespace Remote_Keyboard
{
    class NativeKeyMapper
    {
        private Hashtable keyCodeToVirtualKey;

        //constructor
        public NativeKeyMapper()
        {
            keyCodeToVirtualKey = new Hashtable();
            PopulateHashTables();
        }

        private void PopulateHashTables()
        {
            keyCodeToVirtualKey.Add(1, VirtualKeyShort.CANCEL);

        }

        //returns virtual key
        public uint KeyCodeToVirtualKey( uint keyCode )
        {
            return 0;
        }

        //return keycode
        public uint VirtualKeyToKeyCode( uint virtualKey )
        {
            return 0;
        }
    }
}
