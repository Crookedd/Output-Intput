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
        public void Edit(string Path, string FileName)
        {
            FileStream File = new FileStream(Path, FileMode.OpenOrCreate);
            FileReader(File, FileName);
            EditorFiles1.EditFiles(Path);
            Caretaker.SaveState(EditorFiles1);
            Console.WriteLine("Хотите востановить файл? 1 - da");
            string Number = Console.ReadLine();
            if (Number == "1")
            {
                try
                {
                    File.Close();
                    RestoreData(Path, FileName);
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Не было изменений");
                    Console.ReadKey();
                }
            }
            File.Close();
        }
        static FileTxT FileTxT = new FileTxT();
        static EditorFiles EditorFiles1 = new EditorFiles();
        static Caretaker Caretaker = new Caretaker();
        private static void FileReader(FileStream File, string FileName)
        {
            string str = "";
            var reader = new StreamReader(File);

            while (!reader.EndOfStream)
            {
                str += reader.ReadLine();
            }
            try
            {
                FileTxT.Text.Add(FileName, str);
                FileTxT.FileName.Add(FileName);
                EditorFiles1.Text.Add(FileName, str);
                EditorFiles1.FileName.Add(FileName);
            }
            catch (Exception)
            {
                FileTxT.Text[FileName] = str;
                EditorFiles1.Text[FileName] = str;
            }
            reader.Close();
        }
        private static void RestoreData(string Path, string FileName)
        {
            Caretaker.RestoreState(EditorFiles1);
            using (StreamWriter Writer = new StreamWriter(Path, false))
            {
                Writer.Write(EditorFiles1.Text[FileName]);
            }
        }

    }
}
