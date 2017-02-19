using P2PNET.ObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirKeyboard
{
    public class GameLoop
    {
        public List<ushort> ReceivedKeys { get; set; }
        public List<ushort> SentKeys { get; set; }
        private EventManagerWin eventMgr;
        private Timer gameLoop;
        private ObjectManager objMgr;

        //constructor
        public GameLoop(EventManagerWin eventManager, ObjectManager mObjMgr)
        {
            this.ReceivedKeys = new List<ushort>();
            this.SentKeys = new List<ushort>();

            this.eventMgr = eventManager;
            this.gameLoop = new Timer();
            this.objMgr = mObjMgr;
            StartGameLoopTimer();
        }


        private void StartGameLoopTimer()
        {
            gameLoop.Tick += gameLoop_event;
            gameLoop.Interval = 25;
            gameLoop.Start();
        }

        private async void gameLoop_event(object sender, EventArgs e)
        {
            await SendPressedKeys();

        }

        private async Task SendPressedKeys()
        {
            List<ushort> keysPressedTemp = SentKeys;

            /*
            foreach (ushort keyValue in keysPressedTemp)
            {
                Console.Write(keyValue);
            }
            Console.WriteLine();
            */

            await objMgr.SendToAllPeersAsyncUDP(new KeyMsg(keysPressedTemp));
        }

        public void ReceivedKeyMessage(KeyMsg keyMsg)
        {
            
            List<ushort> receivedKeys = keyMsg.keyValues;
            List<ushort> curKeys = this.ReceivedKeys;

            //compaire to KeyPressed

            //find keys that have been released
            List<ushort> releasedKeys = GetMissingFromSecondList(curKeys, receivedKeys);
            foreach(ushort keyValue in releasedKeys)
            {
                eventMgr.TriggerKeyPress(keyValue, false);
                ReceivedKeys.Remove(keyValue);
            }

            //find keys that have just been pressed
            List<ushort> newPressedKeys = GetMissingFromSecondList(receivedKeys, curKeys);
            foreach (ushort keyValue in newPressedKeys)
            {
                eventMgr.TriggerKeyPress(keyValue, true);
                ReceivedKeys.Add(keyValue);
            }

            /*
            foreach(ushort keyValue in receivedKeys)
            {
                eventMgr.TriggerKeyPress(keyValue, true);
            }
            */

            /*
            Console.Write("Received: ");
            foreach(ushort keyValue in ReceivedKeys)
            {
                Console.Write(keyValue);
            }
            Console.WriteLine();
            */
        }

        private List<ushort> GetMissingFromSecondList(List<ushort> list1, List<ushort> list2)
        {
            List<ushort> missingFromList2 = new List<ushort>();
            foreach(ushort keyValue in list1)
            {
                if(!list2.Contains(keyValue))
                {
                    missingFromList2.Add(keyValue);
                }
            }
            return missingFromList2;
        }

        public async Task KeyDownEvent(List<ushort> keyValues)
        {
            foreach(ushort keyValue in keyValues)
            {
                if (!SentKeys.Contains(keyValue))
                {
                    //no point in sending this key if its already being pressed
                    if(!ReceivedKeys.Contains(keyValue))
                    {
                        SentKeys.Add(keyValue);
                    }
                }
            }
            await SendPressedKeys();
        }

        public async Task KeyUpEvent(List<ushort> keyValues)
        {
            foreach(ushort keyValue in keyValues)
            {
                SentKeys.Remove(keyValue);
            }
            await SendPressedKeys();
        }

    }
}
