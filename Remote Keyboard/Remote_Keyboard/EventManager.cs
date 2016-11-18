using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.InteropServices; //for calling win32 API

namespace Remote_Keyboard
{
    public class EventManager
    {
        //declare win32 function call
        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint numberOfInputs, INPUT[] inputs, int sizeOfInputStructure);

        [DllImport("user32.dll")]
        static extern uint MapVirtualKey(uint uCode, uint uMapType);


        public static uint ScancodeFromVirtualKey(VirtualKeyShort virtualKeyCode)
        {
            uint scanCode = MapVirtualKey((uint)virtualKeyCode, 0);
            return scanCode;
        }

        public static void SendKeyPress(VirtualKeyShort keyCode, bool isDown)
        {
            INPUT input = new INPUT();

            input.type = 1; //keyboard

            input.U.ki.wVk = keyCode;

            /*
            input.Data.Keyboard = new KEYBDINPUT()
            {
                Vk = (ushort)keyCode,
                Scan = 0,
                Flags = 0,
                Time = 0,
                ExtraInfo = IntPtr.Zero,
            };
            */
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
