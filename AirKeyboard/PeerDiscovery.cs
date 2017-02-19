using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using P2PNET.ObjectLayer;

namespace AirKeyboard
{
    public class PeerDiscovery
    {
        private ObjectManager objMgr;
        private Timer hrtBtTimer;
        private HeartBeatMsg heartBeat;

        //constructor
        public PeerDiscovery(ObjectManager mObjMgr)
        {
            hrtBtTimer = new Timer();
            this.objMgr = mObjMgr;
            heartBeat = new HeartBeatMsg();
        }

        public void StartBroadcasting()
        {
            hrtBtTimer.Tick += async (object sender, EventArgs e) =>
            {
                await this.objMgr.SendBroadcastAsyncUDP(heartBeat);
                //Console.WriteLine("sent heartbeat");
            };
            hrtBtTimer.Interval = 1000;
            hrtBtTimer.Start();
        }

    }
}
