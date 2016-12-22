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

        public virtual void TriggerKeyPress(string sdlKey, bool isPressed)
        {
            Console.WriteLine("parent");
        }


        public string NativeKeyToSdl(ushort nativeKey)
        {
            string sdlValue = keyMapper.NativeKeyToSdl(nativeKey);
            return sdlValue;
        }
    }
}
