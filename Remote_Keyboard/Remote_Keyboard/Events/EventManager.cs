using System;
using System.Collections.Generic;
using System.Text;

namespace Remote_Keyboard.Events
{
    public abstract class EventManager
    {
        protected NativeKeyMapper keyMapper;

        //constructor
        public EventManager()
        {

        }

        public abstract void TriggerKeyPress(string sdlKey, bool isPressed);
    }
}
