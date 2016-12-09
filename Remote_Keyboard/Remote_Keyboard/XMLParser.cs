using System.IO;
using System.Xml.Serialization;

namespace Remote_Keyboard
{
    public class XMLParser
    {
        public static string SerializeObject<T>(T keyMsg)
        {
            StringWriter stringwriter = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(keyMsg.GetType());
            serializer.Serialize(stringwriter, keyMsg);
            string outputMsg = stringwriter.ToString();
            return outputMsg;
        }

        public static T DeserializeObject<T>(string msg)
        {
            var stringReader = new StringReader(msg);
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(stringReader);
        }
    }
}
