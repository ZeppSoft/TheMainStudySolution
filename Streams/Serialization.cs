using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CommonLib
{

    [XmlRoot(ElementName ="Root")]
     public class Class4SerializeXML
    {
        [XmlElement("Digit")]
        public int Number { get; set; }

        [XmlIgnore]
        public string Password { get; set; }

        [XmlElement("User")]
        public string Login { get; set; }
    }

    [Serializable]
    public class Class4SerializeBit
    {
        public int Number { get; set; }

        [NonSerialized]
        private string _password;
        public string Password { get { return _password; } set { _password = value; } }
        public string Login { get; set; }
    }
    public static class Serialization
    {
        public static void Try2SerializeBit()
        {
            Class4SerializeBit obj2ser = new Class4SerializeBit() { Number = 7, Login = "Admin", Password = "123" };

            using (FileStream fs = new FileStream("BinState.dat", FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(fs, obj2ser);
            }
        }

        public static void Try2DeSerializeBit()
        {
            Class4SerializeBit obj2ser = null;

            using (FileStream fs = new FileStream("BinState.dat", FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter bf = new BinaryFormatter();

                obj2ser =  bf.Deserialize(fs) as Class4SerializeBit;
            }
        }

        public static void Try2SerializeXML()
        {
            Class4SerializeXML obj2Ser = new Class4SerializeXML() { Number = 10, Password = "123", Login = "Admin" };

            XmlSerializer serializer = new XmlSerializer(typeof(Class4SerializeXML));

            using (FileStream fs = new FileStream("state2.xml",FileMode.OpenOrCreate,FileAccess.Write))
            {
                serializer.Serialize(fs, obj2Ser);
            }
        }

        public static void Try2DeSerializeXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Class4SerializeXML));

            Class4SerializeXML obj2DeSer = null;

            using (FileStream fs = new FileStream("state2.xml", FileMode.Open, FileAccess.Read))
            {
                obj2DeSer = serializer.Deserialize(fs) as Class4SerializeXML;
            }
        }
    }
}
