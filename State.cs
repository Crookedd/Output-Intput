using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Output_Intput
{
    public interface IMemento 
    {
        object GetMemento();
        void SetMemento(object Memento);

    }
    class Memento 
    {
        public Dictionary<string, string> Text { get; set; }
        public List<string> FileName { get; set; }
    }

    public class Caretaker
    {
        private object Memento;
        public void SaveState(IMemento Mem)
        {
            Mem.SetMemento(Memento);
        }
        public void RestoreState(IMemento Mem) 
        {
            Memento = Mem.GetMemento();
        }
    }

    class EditorFiles : IMemento
    {
        public Dictionary<string, string> Text { get; set; }
        public List<string> FileName { get; set; }

        public EditorFiles()
        {
            Text = new Dictionary<string, string>();
        }
        public EditorFiles(string FileName, string Text)
        {
            this.Text.Add(FileName, Text);
        }
        public void EditFiles(string FileName)
        {
            Console.WriteLine("Введите ключевое слово, по которому будет удаляться строка.");
            string KeyWord = Console.ReadLine();
            string[] str = File.ReadAllLines(FileName);
            using (StreamWriter sw = new StreamWriter(FileName))
            {
                sw.AutoFlush = true;
                foreach (string s in str)
                {
                    if (!s.Contains(KeyWord))
                    {
                        sw.WriteLine(s);
                    }
                }
            }
        }
        object IMemento.GetMemento()
        {
            return new Memento { Text = this.Text, FileName = this.FileName };
        }
        void IMemento.SetMemento(object Memento)
        {
            if (Memento is Memento)
            {
                var Temp = Memento as Memento;
                Text = Temp.Text;
                FileName = Temp.FileName;
            }
        }
    }

}
