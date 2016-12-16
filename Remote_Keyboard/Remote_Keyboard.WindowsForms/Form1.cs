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
using Remote_Keyboard.Comms;

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
            airKeyboard.PeerChanged += AirKeyboard_PeerChanged;
            airKeyboard.KeyLogUpdate += AirKeyboard_KeyLogUpdate;
        }

        private void test()
        {
            /*
            PictureButton button = new PictureButton();
            button.Text = "Click Me";
            button.Parent = this;
            button.Bounds = new Rectangle(10, 30, 150, 30);
            button.ForeColor = Color.White;
            button.BackgroundImage = MakeBitmap(Color.Blue, button.Width, button.Height);
            button.PressedImage = MakeBitmap(Color.LightBlue, button.Width, button.Height);
            */   
        }

        // Create a bitmap object and fill it with the specified color.   
        // To make it look like a custom image, draw an ellipse in it.
        Bitmap MakeBitmap(Color color, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(new SolidBrush(color), 0, 0, bmp.Width, bmp.Height);
            g.DrawEllipse(new Pen(Color.DarkGray), 3, 3, width - 6, height - 6);
            g.Dispose();

            return bmp;
        }

        private void AirKeyboard_KeyLogUpdate(object sender, Events.KeyLogUpdateEventArgs e)
        {
            //print keys pressed down
            foreach (string sdlKey in e.keysHeldDown)
            {
                Console.Write(sdlKey + " ");
            }
            Console.WriteLine();
        }

        private void AirKeyboard_PeerChanged(object sender, PeerUpdateEventArgs e)
        {
            //update view list
            peerListView.Items.Clear();
            foreach ( Peer peer in e.peers )
            {
                string[] peerDtl = {
                    peer.lastHeartBeat.senderIpAddress,
                    peer.lastHeartBeat.acceptKeyStrokes.ToString(),

                };
                int OSIndex = (int)peer.lastHeartBeat.platform;
                ListViewItem item = new ListViewItem(peerDtl, imgListOS.Images.Keys[OSIndex]);
                peerListView.Items.Add(item);
            }
        }

        private void DirectConnect(object sender, EventArgs e)
        {

            //if sucessful enable keyboard capture
        }

        //upboard down event
        private void KeyDownEvent(object sender, KeyEventArgs e)
        {
            ushort keyValue = PreProcessKeyEvent(e);

            bool isPressed = true;
            KeyEvent(keyValue, isPressed);
        }

        private void KeyUpEvent(object sender, KeyEventArgs e)
        {
            ushort keyValue = PreProcessKeyEvent(e);

            bool isPressed = false;
            KeyEvent(keyValue, isPressed);
        }

        private void KeyEvent(ushort keyValue, bool isPressed)
        {
            bool keybroadLstn = chkBtnkeyboard.Checked;
            string curTabName = tabControl.SelectedTab.Name;
            if (keybroadLstn && curTabName == "inputTab")
            {
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

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            // Get the graphics device context for the form.
            Graphics g = this.CreateGraphics();

            // Draw each image using the ImageList.Draw() method.
            for (int i = 0; i < imgListOS.Images.Count; i++)
            {
                imgListOS.Draw(g, 30 + i * 30, 30, i);
            }

            // Release the graphics device context.
            g.Dispose();
        }
    }
}
