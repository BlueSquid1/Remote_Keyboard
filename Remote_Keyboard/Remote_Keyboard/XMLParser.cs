using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Remote_Keyboard.Comms;
using System.IO;
using System.Xml.Serialization;

namespace Remote_Keyboard
{
    public class XMLParser
    {
        public static string SerializeObject<T>(T keyMsg)
        {
            //Formatting.Indented uses enter and tabbing to make the output human readable
            return JsonConvert.SerializeObject(keyMsg, Formatting.Indented);


            /*
            StringWriter stringwriter = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(keyMsg.GetType());
            serializer.Serialize(stringwriter, keyMsg);
            string outputMsg = stringwriter.ToString();
            return outputMsg;
            */
        }

        public static T DeserializeObject<T>(string msg)
        {
            return JsonConvert.DeserializeObject<T>(msg);



            /*
            var stringReader = new StringReader(msg);
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(stringReader);
            */
        }

        public static MessageType GetType(string msg)
        {
            JObject jObj = JObject.Parse(msg);
            return (MessageType)((int)jObj["msgType"]);
        }
    }
}
