using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Runtime.InteropServices; //for calling win32 API
using System.Xml; //for xml parsing
using Remote_Keyboard.Events; //handling keyboard events

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
        public EventManagerWin() : base(PlateformID.winForms)
        {

        }

        public override void TriggerKeyPress(string sdlKey, bool isPressed)
        {
            //convert sdl value to native value
            ushort virtualKey = base.keyMapper.SdlToNativeKey(sdlKey);
            ushort scanCode = (ushort)MapVirtualKey(virtualKey, 0);

            uint extendedFlag = 0x100;
            bool isExtended = (scanCode & extendedFlag) != 0;

            uint tempflags = 0;
            if (isExtended)
            {
                tempflags = 0x0001;
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
    }
}
