using System;
using Other;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the text");
            string text = Console.ReadLine();
            Console.WriteLine("Choose an option");
            int opt = Tools.Validate(false);
            List<string> result;
            switch (opt)
            {
                case 1:
                    //text = "2016 год наступит 01-01-2016";
                    result = RegPatterns.DateFinder(text);
                    break;
                case 2:
                    //text = $"< b > Это </ b > текст < i > с </ i > < fontcolor = \"red\" > HTML </ font > кодами";
                    result = RegPatterns.HtmlReplaser(text);
                    break;
                case 3:
                    //text = " Иван: ivan@mail.ru, Петр: p_ivanov@mail.rol.ru";
                    result = RegPatterns.EmailFinder(text);
                    break;
                case 4:
                    result = RegPatterns.NumberValidator(text);
                    break;
                case 5:
                    text = "В 7:55 я встал, позавтракал и к 10:77 пошёл на работу.";
                    result = RegPatterns.TimeCounter(text);
                    break; 
                default: result = null;
                    break;
            }
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            
            Console.ReadLine();
        }
    }
}
