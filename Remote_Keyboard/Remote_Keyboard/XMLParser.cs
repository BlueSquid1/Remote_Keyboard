using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace Remote_Keyboard
{
    public class KeyMessage
    {
        public string sdlKeyValue { get; set; }
        public bool isPressed { get; set; }
    }

    public class XMLParser
    {
        public static string SerializeString(object obj)
        {
            StringWriter stringwriter = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            serializer.Serialize(stringwriter, obj);
            return stringwriter.ToString();
        }

        public static object DeserializeString(string msg)
        {
            var stringReader = new System.IO.StringReader(msg);
            var serializer = new XmlSerializer(typeof(object));
            return serializer.Deserialize(stringReader) as object;
        }



        public static string SerializeKeyPress(KeyMessage keyMsg)
        {
            StringWriter stringwriter = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(keyMsg.GetType());
            serializer.Serialize(stringwriter, keyMsg);
            return stringwriter.ToString();
        }

        public static KeyMessage DeserializeKeyPress(string msg)
        {
            var stringReader = new System.IO.StringReader(msg);
            var serializer = new XmlSerializer(typeof(KeyMessage));
            return serializer.Deserialize(stringReader) as KeyMessage;
        }
    }
}
