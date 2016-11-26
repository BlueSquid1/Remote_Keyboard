using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Remote_Keyboard
{
    class XMLParser
    {
        public static bool PopulateKeyMapFromXML(ref SortedDictionary<string, ushort> sdlKeyToNativeKey)
        {
            XmlReader xmlReader = XmlReader.Create("KeyMapping.xml");
            //skip header section
            xmlReader.MoveToContent();

            xmlReader.MoveToAttribute("id");
            int keyvalue = xmlReader.ReadContentAsInt();

            sdlKeyToNativeKey["F1"] = 1;
            return true;
        }
    }
}
