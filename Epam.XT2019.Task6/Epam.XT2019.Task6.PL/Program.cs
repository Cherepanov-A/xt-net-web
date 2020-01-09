
using Epam.XT2019.Task6.Ioc;
using Epam.XT2019.Task6.LogicContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.XT2019.Task6.PL
{
    class Program
    {

        static void Main(string[] args)
        {
            IUserLogic logic = DependencyResolver.ULogic;
            bool correct = true;
            while (correct)
            {
            Console.WriteLine("Choose an option");
            Console.WriteLine("1: Create user");
            Console.WriteLine("2: Delete user");
            Console.WriteLine("3: Display users");
            Console.WriteLine("0: Exit");
            string option = Console.ReadLine();
           
                switch (option)
                {
                    case "0": correct = false;
                        break;
                    case "1":
                        //User user = new User();
                        Console.WriteLine("Enter name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter ID");
                        string id = Console.ReadLine();
                        //user.Id = int.Parse(id);
                        Console.WriteLine("Enter Date of birth");
                        string dateOfBirth = Console.ReadLine();                        
                        bool success = logic.CreateUser(id ,name, dateOfBirth);
                        if (success)
                        {
                            Console.WriteLine("User saved successfuly");
                        }
                        else
                        {
                            Console.WriteLine("User saving failed, pleace check data");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Enter ID");
                        id = Console.ReadLine();
                        logic.DeleteUser(id);
                        break;
                    case "3":
                        var users = logic.DisplayUsers();
                        foreach (var item in users)
                        {
                            Console.WriteLine(item.Id);
                            Console.WriteLine(item.Name);
                            Console.WriteLine(item.DateOfBirth);
                            Console.WriteLine(item.Age);
                            Console.WriteLine();
                        }
                        break;
                    default:
                        Console.WriteLine("Enter correct value");
                        break;
                }
            }
        }
    }
}
