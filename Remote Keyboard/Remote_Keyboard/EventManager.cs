﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Remote_Keyboard
{
    public class EventManager
    {
        /*
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

            INPUT[] inputArray = new INPUT[] { input };
            uint inputLen = (uint)inputArray.Length;
            uint result = SendInput(inputLen, inputArray, INPUT.Size);

            if (result == 0)
            {
                throw new Exception();
            }
        }
        */
    }
}
