using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Output_Intput
{
    class Keywords
    {
        public void KeyWodrsFiles(string path, string keywords)
        {
            List<string> Files = new List<string>();

            foreach (string FindedFile in Directory.EnumerateFiles(path, keywords, SearchOption.AllDirectories))
            {
                FileInfo fileInfo;
                try
                {
                    fileInfo = new FileInfo(FindedFile);
                    Files.Add(fileInfo.Name);
                }
                catch
                {
                    continue;
                }
            }

            if (Files.Count > 0)
            {
                Console.WriteLine("\n~~~Все найденные файлы~~~\n");
                for (int Index = 0; Index < Files.Count; Index++)
                {
                    Console.WriteLine($"{Files[Index]}\n");
                }
            }
            else
            {
                Console.WriteLine("Нет таких файлов");
            }
        }
    }
}
