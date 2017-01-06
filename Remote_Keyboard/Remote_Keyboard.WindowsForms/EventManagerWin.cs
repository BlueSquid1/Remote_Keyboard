using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Runtime.InteropServices; //for calling win32 API
using System.Xml; //for xml parsing
using Remote_Keyboard.Events; //handling keyboard events
using System.IO;

namespace Remote_Keyboard.WindowsForms
{
    class EventManagerWin : EventManager
    {
        //declare win32 function calls
        [DllImport("user32.dll")]
        private static extern uint SendInput(uint numberOfInputs, INPUT[] inputs, int sizeOfInputStructure);

        [DllImport("user32.dll")]
        private static extern uint MapVirtualKey(uint uCode, uint uMapType);

        //constructor
        public EventManagerWin(Stream keyStrokeFileStream) : base(keyStrokeFileStream, PlateformID.winForms)
        {

        }

        public override void TriggerKeyPress(string sdlKey, bool isPressed)
        {
            //convert sdl value to native value
            ushort virtualKey = base.keyMapper.SdlToNativeKey(sdlKey);
            ushort scanCode = (ushort)MapVirtualKey(virtualKey, 0);

            bool isExtended = IsExtended(sdlKey);

            uint tempflags = 0;
            if (isExtended)
            {
                tempflags |= 0x0001;
            }
            if (!isPressed)
            {
                uint KEYEVENTF_KEYUP = 0x0002;
                tempflags |= KEYEVENTF_KEYUP;
            }


            INPUT input = new INPUT();

            input.type = (uint)1; //keyboard

            input.U.ki.wVk = virtualKey;
            input.U.ki.wScan = scanCode;
            input.U.ki.time = 0;
            input.U.ki.dwFlags = tempflags;

            INPUT[] inputArray = new INPUT[] { input };
            uint inputLen = (uint)inputArray.Length;
            uint result = SendInput(inputLen, inputArray, INPUT.Size);

            if (result == 0)
            {
                throw new Exception();
            }
        }

        private bool IsExtended(string sdlKey)
        {
            /*
            taken from:
            https://msdn.microsoft.com/en-us/library/windows/desktop/ms646267(v=vs.85).aspx

            The extended-key flag indicates whether the keystroke message originated from one of the 
            additional keys on the enhanced keyboard. The extended keys consist of the ALT and CTRL keys 
            on the right-hand side of the keyboard; the INS, DEL, HOME, END, PAGE UP, PAGE DOWN, and 
            arrow keys in the clusters to the left of the numeric keypad; the NUM LOCK key; the BREAK 
            (CTRL+PAUSE) key; the PRINT SCRN key; and the divide (/) and ENTER keys in the numeric keypad. 
            The extended-key flag is set if the key is an extended key.
            */

            string[] extendedKeysSDL = {
                "Right Alt",
                "Right Ctrl",
                "Insert",
                "Delete",
                "Home",
                "End",
                "PageUp",
                "PageDown",
                "Up",
                "Right",
                "Left",
                "Down",
                "Numlock",
                "PrintScreen",
                "Keypad /",
                "Keypad Enter"
            };

            foreach(string extKey in extendedKeysSDL)
            {
                if(extKey == sdlKey)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
