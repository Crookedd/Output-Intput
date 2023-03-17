using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Output_Intput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ElementPath = @"C:\";
            Console.WriteLine("Введите путь к файлу: ");
            string Path = Console.ReadLine();
            Console.WriteLine("Здравствуйте!! Что вы хотите сделать?\n\n 1.Удалить строку по ключевому слову.\n2.Поиск файлов по ключевому слову.\n3.Индексация.\n Введите цифру выбора:");
            string Choice = Console.ReadLine();
            switch (Choice) 
            {
                case "1":
                    Console.WriteLine("Введите название файла: ");
                    string FileName = Console.ReadLine();
                    Editor Editor = new Editor();
                    Editor.Edit(ElementPath + Path + "\\" + FileName + ".txt", FileName);
                    Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine("Введите ключевое слово с * (Пример: Файл* )");
                    string Words = Console.ReadLine();
                    Keywords Keywords = new Keywords();
                    Keywords.KeyWodrsFiles(ElementPath + Path, Words);
                    break;
                case "3":
                    Indexsing Indexsing = new Indexsing();
                    Indexsing.Indexator(ElementPath + Path);
                    break;
                default:
                    Console.WriteLine();
                    break;
            }
            Console.ReadLine();
        }
    }
}
