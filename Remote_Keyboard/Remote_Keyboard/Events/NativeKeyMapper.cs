using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Remote_Keyboard.Events
{
    public enum PlateformID
    {
        winForms = 0,
        droid = 1,
        ios = 2,
        osx = 3
    }

    public class NativeKeyMapper
    {
        private Dictionary<string, ushort> sdlKeyToNativeKey = new Dictionary<string, ushort>();
        private Dictionary<ushort, string> nativeKeyToSdlKey = new Dictionary<ushort, string>();
        
        //constructor
        public NativeKeyMapper(Stream keyStrokeFileStream, PlateformID plateform)
        {
            string pltfrmNme = "";
            switch(plateform)
            {
                case PlateformID.winForms:
                    pltfrmNme = "WindowsValue";
                    break;
                case PlateformID.droid:
                    pltfrmNme = "DroidValue";
                    break;
                case PlateformID.ios:
                    pltfrmNme = "iOSValue";
                    break;
            }
            PopulateKeyMapping(keyStrokeFileStream, pltfrmNme);
            
        }

        private void PopulateKeyMapping(Stream keyStrokeFileStream, string plateform)
        {
            //create an xmlReader
            XmlReaderSettings readerSettings = new XmlReaderSettings();
            readerSettings.IgnoreComments = true;
            XmlReader reader = XmlReader.Create(keyStrokeFileStream, readerSettings);

            //conver to XmlDocument
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);

            //loop through each key
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                XmlAttribute nameAttribute = node.Attributes["name"];
                string SDLKey = nameAttribute?.InnerText; //or loop through its children as well

                //get key value for windows
                string keyValueStr = node.SelectSingleNode("WindowsValue").InnerText;
                if (keyValueStr != "")
                {
                    ushort keyValue = Convert.ToUInt16(keyValueStr);

                    //store key
                    sdlKeyToNativeKey[SDLKey] = keyValue;
                    nativeKeyToSdlKey[keyValue] = SDLKey;
                }
            }

        }

        public ushort SdlToNativeKey(string sdlKey)
        {
            return sdlKeyToNativeKey[sdlKey];
        }

        public string NativeKeyToSdl(ushort nativeKey)
        {
            return nativeKeyToSdlKey[nativeKey];
        }
    }
}
