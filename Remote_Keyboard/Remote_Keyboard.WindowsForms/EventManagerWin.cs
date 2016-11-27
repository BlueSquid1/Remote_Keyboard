using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Runtime.InteropServices; //for calling win32 API
using System.Xml;

namespace Remote_Keyboard.WindowsForms
{
    class EventManagerWin : EventManager
    {
        //declare win32 function calls
        [DllImport("user32.dll")]
        private static extern uint SendInput(uint numberOfInputs, INPUT[] inputs, int sizeOfInputStructure);

        [DllImport("user32.dll")]
        private static extern uint MapVirtualKey(uint uCode, uint uMapType);

        public EventManagerWin()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("KeyMapping.xml");

            //loop through each key
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                string SDLKey = node.Attributes["name"]?.InnerText; //or loop through its children as well

                //get key value for windows
                string keyValueStr = node.SelectSingleNode("WindowsValue").InnerText;
                if (keyValueStr != "")
                {
                    ushort keyValue = Convert.ToUInt16(keyValueStr);

                    //store key
                    sdlKeyToNativeKey[SDLKey] = keyValue;
                    nativeKeyToSdlKey[keyValue] = SDLKey;
                }
            }
        }

        public override void TriggerKeyPress(string sdlKey, bool isPressed)
        {

            //Console.WriteLine( "scan code = " + scanCode );

            //convert to virtual key
            //VirtualKeyShort x = (VirtualKeyShort)VirtualKeyFromScanCode(scanCode);



            /*
            INPUT input = new INPUT();

            input.type = 1; //keyboard

            input.U.ki.wVk = virutalKey;

            INPUT[] inputArray = new INPUT[] { input };
            uint inputLen = (uint)inputArray.Length;
            uint result = SendInput(inputLen, inputArray, INPUT.Size);

            if (result == 0)
            {
                throw new Exception();
            }
            */
        }

        public override ushort SdlKeyToNativeKey(string sdlKey)
        {
            throw new NotImplementedException();
        }

        public override string NativeKeytoSdlKey(ushort scanCode)
        {
            throw new NotImplementedException();
        }
    }
}
