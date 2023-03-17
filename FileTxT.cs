using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Output_Intput
{
    [Serializable]
    class FileTxT
    {
        public List<string> FileName { get; set; }
        public Dictionary<string, string> Text { get; set; }
        public FileTxT()
        {
            FileName = new List<string>();
            Text = new Dictionary<string, string>();
        }
        public FileTxT(string fileName, string text)
        {
            this.FileName.Add(fileName);
            this.Text.Add(fileName, text);
        }

        public void BinarySerialization(FileStream fs)
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this);
            fs.Flush();
            fs.Close();
            Console.WriteLine("Объект сериализован");
        }

        public void BinaryDeserialization(FileStream fs)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileTxT deserialized = (FileTxT)bf.Deserialize(fs);
            FileName = deserialized.FileName;
            Text = deserialized.Text;
            fs.Close();
            Console.WriteLine("Объект Десериализован");
            Console.WriteLine($"FileName: {FileName}\nText: {Text}");
        }

        public void XmlSerialization(FileStream fs)
        {
            XmlSerializer xmlserializer = new XmlSerializer(typeof(FileTxT));
            xmlserializer.Serialize(fs, this);
            fs.Flush();
            fs.Close();
            Console.WriteLine("Объект сериализован");
        }

        public void XmlDeserialization(FileStream fs)
        {
            XmlSerializer xmlserializer = new XmlSerializer(typeof(FileTxT));
            FileTxT deserialized = (FileTxT)xmlserializer.Deserialize(fs);
            FileName = deserialized.FileName;
            Text = deserialized.Text;
            fs.Close();
            Console.WriteLine("Объект Десериализован");
            Console.WriteLine($"FileName: {FileName}\nText: {Text}");
        }
    }
}
