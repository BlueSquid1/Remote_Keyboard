using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace Remote_Keyboard
{
    public class XMLParser
    {
        public static string ParseKeyPress(string sdlValue, bool isPressed)
        {
            return sdlValue + isPressed.ToString();
        }
    }
}
