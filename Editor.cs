using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Output_Intput
{
    class Editor
    {
        public void Edit(string path, string fileName)
        {
            Console.WriteLine("Что вы хотите сделать?\n\n1.Бинарную Сериализуцию.\n2.Бинарную Десериализацию(если конечно была совершнена сериализация)\n" +
                "3.XML Сериализацию.\n4.XMLДесериализацию(если конечно была совершнена сериализация)\n5.Поиск файла по ключевому слову.");
            int Choice = 0;
            while (Choice < 1 || Choice > 5)
            {
                if (int.TryParse(Convert.ToString(Console.ReadLine()), out Choice) == false)
                {
                    Console.WriteLine("Данные введены неверно. Попробуйте ещё раз");
                }
            }

            switch (Choice)
            {
                case 1:
                    FileStream fs = new FileStream("C:\\Serialize.bin", FileMode.OpenOrCreate, FileAccess.Write);
                    FileTxT txT = new FileTxT();
                    txT.BinarySerialization(fs);
                    break;
                case 2:
                    fs = new FileStream("C:\\Serialize.bin", FileMode.OpenOrCreate, FileAccess.Read);
                    FileTxT txT1 = new FileTxT();
                    txT1.BinaryDeserialization(fs);
                    break;
                case 3:
                    fs = new FileStream("C:\\XMLSerialize.xml", FileMode.OpenOrCreate, FileAccess.Write);
                    FileTxT txT2 = new FileTxT();
                    txT2.XmlSerialization(fs);
                    break;
                case 4:
                    fs = new FileStream("C:\\XMLSerialize.xml", FileMode.OpenOrCreate, FileAccess.Read);
                    FileTxT txT3 = new FileTxT();
                    txT3.XmlDeserialization(fs);
                    break;
                case 5:
                    Console.WriteLine("Введите ключевое слово с * (Пример: Файл* )");
                    string words = Console.ReadLine();
                    Keywords keywords = new Keywords();
                    keywords.KeyWodrsFiles(path, words);
                    break;
                default:
                    Console.WriteLine();
                    break;
            }

        }

        static FileTxT fileTxT = new FileTxT();
        private static void FileReader(string path, string FileName)
        {
            FileStream file = new FileStream(path + FileName, FileMode.OpenOrCreate);
            string str = "";
            var reader = new StreamReader(file);

            while (!reader.EndOfStream)
            {
                str += reader.ReadLine();
            }
            try
            {
                fileTxT.Text.Add(FileName, str);
                fileTxT.FileName.Add(FileName);
            }
            catch (Exception)
            {
                fileTxT.Text[FileName] = str;
            }
            reader.Close();
        }
    }
}
