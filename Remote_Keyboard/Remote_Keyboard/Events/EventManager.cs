using System;
using System.Collections.Generic;
using System.Text;

namespace Remote_Keyboard.Events
{
    public abstract class EventManager
    {
        protected NativeKeyMapper keyMapper;

        //constructor
        public EventManager(PlateformID plateform)
        {
            this.keyMapper = new NativeKeyMapper(plateform);
        }

        public abstract void TriggerKeyPress(string sdlKey, bool isPressed);


        public string NativeKeyToSdl(ushort nativeKey)
        {
            return keyMapper.NativeKeyToSdl(nativeKey);
        }
    }
}
