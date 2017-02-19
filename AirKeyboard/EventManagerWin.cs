using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Runtime.InteropServices; //for calling win32 API
using System.Xml; //for xml parsing
using System.IO;

namespace AirKeyboard
{
    public class EventManagerWin
    {
        //declare win32 function calls
        [DllImport("user32.dll")]
        private static extern uint SendInput(uint numberOfInputs, INPUT[] inputs, int sizeOfInputStructure);

        [DllImport("user32.dll")]
        private static extern uint MapVirtualKey(uint uCode, uint uMapType);

        //constructor
        public EventManagerWin()
        {

        }

        public void TriggerKeyPress(ushort virtualKey, bool isPressed)
        {
            //convert sdl value to native value
            ushort scanCode = (ushort)MapVirtualKey(virtualKey, 0);

            bool isExtended = IsExtended(virtualKey);

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
            Console.WriteLine("1");
            uint result = SendInput(inputLen, inputArray, INPUT.Size);
            Console.WriteLine("2");
            if (result == 0)
            {
                throw new Exception();
            }
        }

        private bool IsExtended(ushort sdlKey)
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

            ushort[] extendedKeysSDL = {
                165, //"Right Alt",
                165, //"Right Ctrl",
                45, //"Insert",
                46, //"Delete",
                36, //"Home",
                35, //"End",
                33, //"PageUp",
                34, //"PageDown",
                38, //"Up",
                39, //"Right",
                37, //"Left",
                40, //"Down",
                144, //"Numlock",
                44, //"PrintScreen",
                //"Keypad /",
                //"Keypad Enter"
            };

            foreach (ushort extKey in extendedKeysSDL)
            {
                if (extKey == sdlKey)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
