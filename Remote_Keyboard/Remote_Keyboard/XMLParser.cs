using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace Remote_Keyboard
{
    class XMLParser
    {
        public static bool PopulateKeyMapFromXML(ref SortedDictionary<string, ushort> sdlKeyToNativeKey)
        {
            XmlReader xmlReader = XmlReader.Create("Remote_Keyboard.Droid.KeyMapping.xml");
            //skip header section
            xmlReader.MoveToContent();

            xmlReader.MoveToAttribute("id");
            string keyvalue = xmlReader.Value;

            sdlKeyToNativeKey["F1"] = 1;
            return true;
        }
    }
}
