﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Remote_KeyboardPortable;

namespace Remote_Keyboard.WindowsForms
{
    public partial class Form1 : Form
    {
        private UdpListener udp = new UdpListener(1000);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void keyTest_Click(object sender, EventArgs e)
        {
            udp.BroadcastSend("hello world");
        }

        private void StartListerning_Click(object sender, EventArgs e)
        {
            udp.StartingListening();
        }
    }
}
