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

namespace Remote_Keyboard.WindowsForms
{
    public partial class Form1 : Form
    {
        private EventManagerWin eventManager;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            eventManager = new EventManagerWin();
        }

        private void keyTest_Click(object sender, EventArgs e)
        {
            BaseStation baseStation = BaseStation.GetInstance(10000);
            baseStation.BroadcastSendAsync("hello world");
        }

        private void StartListerning_Click(object sender, EventArgs e)
        {
            BaseStation baseStation = BaseStation.GetInstance(10000);
            baseStation.StartingListeningAsync();
        }

        private void testKey_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(2000);
            eventManager.TriggerKeyPress("F12", true);
            System.Threading.Thread.Sleep(100);
            eventManager.TriggerKeyPress("F12", false);
        }
    }
}
