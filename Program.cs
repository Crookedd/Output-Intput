using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Output_Intput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string Elementpath = @"C:\";
            Console.WriteLine("Введите путь к файлу: ");
            string Path = Console.ReadLine();
            Console.WriteLine("Введите название файла .txt(важно): ");
            string fileName = Console.ReadLine();
            Editor editor = new Editor();
            editor.Edit(Elementpath + Path, "\\" + fileName);
            Console.ReadLine();
        }
    }
}
