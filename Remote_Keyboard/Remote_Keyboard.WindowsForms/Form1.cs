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
using System.IO;

namespace Remote_Keyboard.WindowsForms
{
    public partial class Form1 : Form
    {
        //for distinguishing between left and right keys
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);


        //because windows struggles to distinguish between left and right shift keys need to remember which is which for it
        private bool rightShiftDown = false;
        private bool leftShiftDown = false;
        private bool rightControlDown = false;
        private bool leftControlDown = false;

        private AirKeyboard airKeyboard;
        private ClipboardEventsWin clipboardEvent;

        public Form1()
        {
            clipboardEvent = new ClipboardEventsWin(this);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream fileStream = new FileStream("KeyMapping.xml", FileMode.Open);
            EventManagerWin eventManager = new EventManagerWin(fileStream);

            airKeyboard = new AirKeyboard(eventManager, this);
            airKeyboard.PeerChanged += AirKeyboard_PeerChanged;
            airKeyboard.KeyLogUpdate += AirKeyboard_KeyLogUpdate;
        }

        /*
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
        */

        private void AirKeyboard_KeyLogUpdate(object sender, Events.KeyLogUpdateEventArgs e)
        {
            //print keys pressed down
            string keyPressedList = "";
            for(int i = 0; i < e.keysHeldDown.Count; ++i)
            {
                keyPressedList += e.keysHeldDown[i] + ", ";
            }

            KeysPressed.Text = keyPressedList;
        }

        private void AirKeyboard_PeerChanged(object sender, PeerUpdateEventArgs e)
        {
            //airKeyboard.baseStation.knownPeers[0].aliveTimeout.SynchronizingObject = this;
            //ISynchronizeInvoke


            //update view list
            peerListView.Items.Clear();
            foreach ( Peer peer in e.peers )
            {
                string[] peerDtl = {
                    peer.lastHeartBeat.senderIpAddress,
                    peer.lastHeartBeat.acceptKeyStrokes.ToString(),
                    peer.activePeer.ToString()

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
            ushort keyValue = PreProcessKeyEventDown(e);
            List<ushort> keyValues = new List<ushort>();
            keyValues.Add(keyValue);

            bool isPressed = true;
            KeyEvents(keyValues, isPressed);
        }

        private void KeyUpEvent(object sender, KeyEventArgs e)
        {
            List<ushort> keyValues = PreProcessKeyEventUp(e);

            bool isPressed = false;
            KeyEvents(keyValues, isPressed);
        }

        private void KeyEvents(List<ushort> keyValue, bool isPressed)
        {
            bool keybroadLstn = chkBtnkeyboard.Checked;
            if (keybroadLstn && isInputTab())
            {
                airKeyboard.SendKeyList(keyValue, isPressed);
            }
        }

        private bool isInputTab()
        {
            string curTabName = tabControl.SelectedTab.Name;
            return curTabName == "inputTab";
        }

        private ushort PreProcessKeyEventDown(KeyEventArgs e)
        {
            ushort keyValue = (ushort)e.KeyValue;
            if ( e.KeyCode == Keys.ShiftKey )
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

            if( e.KeyCode == Keys.ControlKey )
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

        private List<ushort> PreProcessKeyEventUp(KeyEventArgs e)
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
            if(keyPresses.Count <= 0)
            {
                keyPresses.Add(WindowsDumbKeyValue);
            }

            return keyPresses;
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            // Get the graphics device context for the form.
            Graphics g = this.CreateGraphics();

            // Draw each image using the ImageList.Draw() method.
            for (int i = 0; i < imgListOS.Images.Count; i++)
            {
                int imgWidth = imgListOS.Images[i].Width;
                imgListOS.Draw(g, this.Width - imgWidth - (i) * imgWidth, 40, i);
            }

            // Release the graphics device context.
            g.Dispose();
        }

        
        protected override bool ProcessTabKey(bool forward)
        {
            //when this is false tab will trigger a key press event
            return false;
        }


        protected override bool ProcessKeyPreview(ref Message m)
        {
            Keys key = (Keys)m.WParam;

            bool baseResult = base.ProcessKeyPreview(ref m);

            if (key == Keys.Right && isInputTab())
            {
                //tell windows that this event has already been handled
                return true;
            }
            return baseResult;
        }

        protected override void WndProc(ref Message m)
        {
            if(clipboardEvent == null)
            {
                base.WndProc(ref m);
                return;
            }
            bool isHandledByClipboard = clipboardEvent.HandleWndProc(m);
            if (!isHandledByClipboard)
            {
                base.WndProc(ref m);
            }
        }
    }
}
