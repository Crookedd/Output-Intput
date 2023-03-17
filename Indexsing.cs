using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Output_Intput
{
    class Indexsing
    {
        List<string> List = new List<string>();
        public void Indexator(string Path)
        {
            Console.WriteLine("Введите расширение для индексации. ");
            List.Add(Console.ReadLine());
            Console.WriteLine("\nВведите имя файла для сохранения результата.");
            string FileName = Path + "\\" + Console.ReadLine();
            FileStream FileStream = new FileStream(FileName, FileMode.OpenOrCreate);
            using (StreamWriter Writer = new StreamWriter(FileStream))
                foreach (string str in List)
                {
                    var ExtensionFiles = Directory.EnumerateFiles(Path, "*." + str, SearchOption.AllDirectories);
                    Writer.WriteLine(str + ":\n");
                    foreach (string File in ExtensionFiles)
                    {
                        string FName = File.Substring(Path.Length);
                        Writer.WriteLine(FName);
                    }
                }
            FileStream.Close();
            
        }
    }
}
