using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirKeyboard
{
    public class ProccessInput
    {
        //for distinguishing between left and right keys
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);


        //because windows struggles to distinguish between left and right shift keys need to remember which is which for it
        private bool rightShiftDown = false;
        private bool leftShiftDown = false;
        private bool rightControlDown = false;
        private bool leftControlDown = false;



        public ushort PreProcessKeyEventDown(KeyEventArgs e)
        {
            ushort keyValue = (ushort)e.KeyValue;
            if (e.KeyCode == Keys.ShiftKey)
            {
                if (Convert.ToBoolean(GetAsyncKeyState(Keys.RShiftKey)) && !rightShiftDown)
                {
                    keyValue = (ushort)Keys.RShiftKey;
                    rightShiftDown = true;
                }
                else if (Convert.ToBoolean(GetAsyncKeyState(Keys.LShiftKey)) && !leftShiftDown)
                {
                    keyValue = (ushort)Keys.LShiftKey;
                    leftShiftDown = true;
                }
                else
                {
                    //failed to predict key. Just return a value according to the state
                    if (rightShiftDown)
                    {
                        keyValue = (ushort)Keys.RShiftKey;
                        rightShiftDown = true;
                    }
                    else
                    {
                        keyValue = (ushort)Keys.LShiftKey;
                        leftShiftDown = true;
                    }
                }
            }

            if (e.KeyCode == Keys.ControlKey)
            {
                if (Convert.ToBoolean(GetAsyncKeyState(Keys.RControlKey)) && !rightControlDown)
                {
                    keyValue = (ushort)Keys.RControlKey;
                    rightControlDown = true;
                }
                else if (Convert.ToBoolean(GetAsyncKeyState(Keys.LControlKey)) && !leftControlDown)
                {
                    keyValue = (ushort)Keys.LControlKey;
                    leftControlDown = true;
                }
                else
                {
                    //failed to predict key. Just return a value according to the state
                    if (rightControlDown)
                    {
                        keyValue = (ushort)Keys.RControlKey;
                        rightControlDown = true;
                    }
                    else
                    {
                        keyValue = (ushort)Keys.LControlKey;
                        leftControlDown = true;
                    }
                }

            }
            return keyValue;
        }

        public List<ushort> PreProcessKeyEventUp(KeyEventArgs e)
        {
            //this is windows best guess of what key I released
            ushort WindowsDumbKeyValue = (ushort)e.KeyValue;

            List<ushort> keyPresses = new List<ushort>();

            //based on the current state try to guess what actually key has just been released
            if (e.KeyCode == Keys.ShiftKey)
            {
                //clear all the shifts keys that have been pressed down
                if (rightShiftDown)
                {
                    ushort RShiftValue = (ushort)Keys.RShiftKey;
                    keyPresses.Add(RShiftValue);
                    rightShiftDown = false;
                }
                if (leftShiftDown)
                {
                    ushort LShiftValue = (ushort)Keys.LShiftKey;
                    keyPresses.Add(LShiftValue);
                    leftShiftDown = false;
                }
            }

            if (e.KeyCode == Keys.ControlKey)
            {
                if (rightControlDown)
                {
                    ushort RControlValue = (ushort)Keys.RControlKey;
                    keyPresses.Add(RControlValue);
                    rightControlDown = false;
                }
                if (leftControlDown)
                {
                    ushort LControlValue = (ushort)Keys.LControlKey;
                    keyPresses.Add(LControlValue);
                    leftControlDown = false;
                }
            }

            //make sure to populate the return list with 
            //windows dumb key value if not populate already
            if (keyPresses.Count <= 0)
            {
                keyPresses.Add(WindowsDumbKeyValue);
            }

            return keyPresses;
        }


    }
}
