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
        public void KeyWodrsFiles(string Path, string Keywords)
        {
            List<string> Files = new List<string>();

            foreach (string FindedFile in Directory.EnumerateFiles(Path, Keywords, SearchOption.AllDirectories))
            {
                FileInfo FileInfo;
                try
                {
                    FileInfo = new FileInfo(FindedFile);
                    Files.Add(FileInfo.Name);
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
