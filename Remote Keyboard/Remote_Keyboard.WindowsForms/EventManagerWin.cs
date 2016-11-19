using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Runtime.InteropServices; //for calling win32 API

namespace Remote_Keyboard.WindowsForms
{
    class EventManagerWin : EventManager
    {
        //declare win32 function calls
        [DllImport("user32.dll")]
        private static extern uint SendInput(uint numberOfInputs, INPUT[] inputs, int sizeOfInputStructure);

        [DllImport("user32.dll")]
        private static extern uint MapVirtualKey(uint uCode, uint uMapType);


        private uint ScancodeFromVirtualKey(VirtualKeyShort virtualKeyCode)
        {
            uint scanCode = MapVirtualKey((uint)virtualKeyCode, 0);
            return scanCode;
        }

        public void SendKeyPress(VirtualKeyShort keyCode, bool isDown)
        {
            INPUT input = new INPUT();

            input.type = 1; //keyboard

            input.U.ki.wVk = keyCode;

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
