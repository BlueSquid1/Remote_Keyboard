using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Remote_Keyboard.Events
{
    public abstract class EventManager
    {
        protected NativeKeyMapper keyMapper;


        //constructor
        public EventManager(Stream keyStrokeFileStream, PlateformID plateform)
        {
            this.keyMapper = new NativeKeyMapper(keyStrokeFileStream, plateform);
        }

        public abstract void TriggerKeyPress(string sdlKey, bool isPressed);


        public string NativeKeyToSdl(ushort nativeKey)
        {
            string sdlValue = keyMapper.NativeKeyToSdl(nativeKey);
            return sdlValue;
        }
    }
}
