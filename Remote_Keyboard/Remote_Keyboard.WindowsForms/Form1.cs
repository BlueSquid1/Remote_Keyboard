using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Remote_Keyboard;
using Remote_Keyboard.Common;
using System.Runtime.InteropServices;

namespace Remote_Keyboard.WindowsForms
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        private AirKeyboard airKeyboard;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EventManagerWin eventManager = new EventManagerWin();
            airKeyboard = new AirKeyboard(eventManager);
        }

        private void DirectConnect(object sender, EventArgs e)
        {

            //if sucessful enable keyboard capture
        }

        //upboard down event
        private void KeyDownEvent(object sender, KeyEventArgs e)
        {
            ushort keyValue = PreProcessKeyEvent(e);

            bool keybroadLstn = chkBtnkeyboard.Checked;
            string curTabName = tabControl.SelectedTab.Name;
            if (keybroadLstn && curTabName == "inputTab")
            {
                bool isPressed = true;
                airKeyboard.SendKey(keyValue, isPressed);
            }
        }

        private ushort PreProcessKeyEvent(KeyEventArgs e)
        {
            ushort keyValue = (ushort)e.KeyValue;
            if ( e.KeyCode == Keys.ShiftKey )
            {
                if (Convert.ToBoolean(GetAsyncKeyState(Keys.RShiftKey)))
                {
                    keyValue = (ushort)Keys.RShiftKey;
                }
                else
                {
                    keyValue = (ushort)Keys.LShiftKey;
                }
            }

            if( e.KeyCode == Keys.ControlKey )
            {
                if (Convert.ToBoolean(GetAsyncKeyState(Keys.RControlKey)))
                {
                    keyValue = (ushort)Keys.RControlKey;
                }
                else
                {
                    keyValue = (ushort)Keys.LControlKey;
                }
            }
            return keyValue;
        }
    }
}
