using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using P2PNET.ObjectLayer;
using P2PNET.TransportLayer;

namespace AirKeyboard
{
    public partial class Form1 : Form
    {

        private List<string> KnownPeers;
        private GameLoop gameLoop;

        private ProccessInput proccInput;
        private ObjectManager objMgr;
        private PeerDiscovery peerDiscovery;
        private EventManagerWin eventManager;

        private int portNum = 8080;

        public Form1()
        {
            objMgr = new ObjectManager(portNum, false);
            proccInput = new ProccessInput();
            peerDiscovery = new PeerDiscovery(objMgr);
            KnownPeers = new List<string>();
            eventManager = new EventManagerWin();
            gameLoop = new GameLoop(eventManager, objMgr);
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            objMgr.ObjReceived += ObjMgr_ObjReceived;
            objMgr.PeerChange += ObjMgr_PeerChange;
            await objMgr.StartAsync();
            
            peerDiscovery.StartBroadcasting();
        }

        private void ObjMgr_PeerChange(object sender, P2PNET.TransportLayer.EventArgs.PeerChangeEventArgs e)
        {
            KnownPeers.Clear();
            lvPeers.Items.Clear();
            foreach ( Peer peer in e.Peers )
            {
                KnownPeers.Add(peer.IpAddress);
                ListViewItem item = new ListViewItem(peer.IpAddress);
                lvPeers.Items.Add(item);
            }
        }

        private void ObjMgr_ObjReceived(object sender, P2PNET.ObjectLayer.EventArgs.ObjReceivedEventArgs e)
        {
            switch(e.Meta.ObjectType)
            {
                case "KeyMsg":
                    KeyMsg keyMsg = e.Obj.GetObject<KeyMsg>();
                    ProccessKeyMsg(keyMsg);
                    break;
                case "HeartBeatMsg":
                    break;
                default:
                    Console.WriteLine("unknown file type");
                    break;
            }
        }

        private void ProccessKeyMsg(KeyMsg keyMsg)
        {
            gameLoop.ReceivedKeyMessage(keyMsg);

            UpdateKeysDisplay();
        }


        //upboard down event
        private async void KeyDownEvent(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            ushort keyValue = proccInput.PreProcessKeyEventDown(e);
            List<ushort> keyValues = new List<ushort>();
            keyValues.Add(keyValue);
            await gameLoop.KeyDownEvent(keyValues);
            UpdateKeysDisplay();
        }

        private async void KeyUpEvent(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            List<ushort> keyValues = proccInput.PreProcessKeyEventUp(e);
            await gameLoop.KeyUpEvent(keyValues);

            UpdateKeysDisplay();
        }
        


        private void UpdateKeysDisplay()
        {
            txtPressKeys.Text = "";
            foreach(ushort keyValue in gameLoop.ReceivedKeys)
            {
                txtPressKeys.Text += ((Keys)keyValue).ToString() + ", ";
            }

            foreach (ushort keyValue in gameLoop.SentKeys)
            {
                txtPressKeys.Text += ((Keys)keyValue).ToString() + ", ";
            }
        }

        protected override bool ProcessTabKey(bool forward)
        {
            //when this is false tab will trigger a key press event
            return false;
        }


        /*
        protected override bool ProcessKeyPreview(ref Message m)
        {
            Keys key = (Keys)m.WParam;

            bool baseResult = base.ProcessKeyPreview(ref m);

            if(key == Keys.Right)
            {
                //tell windows that this event has already been handled
                return true;
            }

            return base.ProcessKeyPreview(ref m);
        }
        */


        private async void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                await objMgr.DirrectConnectAsyncTCP(txtIpAddress.Text);
            }
            catch
            {
                //failed to connect
                MessageBox.Show("Failed to connect to peer: " + txtIpAddress.Text);
            }
        }
    }
}
