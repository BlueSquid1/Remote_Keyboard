using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using Android.Content.Res;
using System.Xml;
using Remote_Keyboard.Events;

namespace Remote_Keyboard.Droid
{
    class EventManagerDroid : EventManager
    {
        //constructor
        public EventManagerDroid(Stream keyStrokeFileStream) : base(keyStrokeFileStream, PlateformID.droid)
        {
            /*
            //StreamReader streamReader = new StreamReader(assets.Open("KeyMapping.xml"));
            XmlDocument doc = new XmlDocument();
            doc.Load(assets.Open("KeyMapping.xml"));

            //loop through each key
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                string SDLKey = node.Attributes["name"]?.InnerText; //or loop through its children as well

                //get key value for windows
                string keyValueStr = node.SelectSingleNode("DroidValue").InnerText;
                ushort keyValue = Convert.ToUInt16(keyValueStr);

                //store key
                sdlKeyToNativeKey[SDLKey] = keyValue;
                nativeKeyToSdlKey[keyValue] = SDLKey;
            }
            */
        }

        public override void TriggerKeyPress(string sdlKey, bool isPressed)
        {

        }
    }
}