
using Epam.XT2019.Task6.Entities;
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
            IUserLogic uLogic = DependencyResolver.ULogic;
            IAwardLogic awLogic = DependencyResolver.ALogic;
            bool correct = true;

            while (correct)
            {
                Console.WriteLine("Choose an option");
                Console.WriteLine("1: Create user");
                Console.WriteLine("2: Delete user");
                Console.WriteLine("3: Display users");
                Console.WriteLine("4: Create award");
                Console.WriteLine("5: Delete award");
                Console.WriteLine("6: Display all awards");
                Console.WriteLine("7: To award");
                Console.WriteLine("8: Display user awards");
                Console.WriteLine("0: Exit");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "0":
                        correct = false;
                        break;
                    case "1":

                        Console.WriteLine("Enter name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Date of birth");
                        string dateOfBirth = Console.ReadLine();
                        bool success = uLogic.CreateUser(name, dateOfBirth);
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
                        string id = Console.ReadLine();
                        int numId;
                        if (int.TryParse(id, out numId))
                        {
                            uLogic.DeleteUser(numId);
                        }
                        else
                        {
                            Console.WriteLine("ID is NaN");
                        }
                        break;
                    case "3":
                        var users = uLogic.DisplayUsers();
                        foreach (var item in users)
                        {
                            Console.WriteLine(item.Id);
                            Console.WriteLine(item.Name);
                            Console.WriteLine(item.DateOfBirth);
                            Console.WriteLine(item.Age);
                            Console.WriteLine();
                        }
                        break;
                    case "4":
                        Console.WriteLine("Enter award name");
                        string awName = Console.ReadLine();
                        awLogic.CreateAward(awName);
                        break;
                    case "5":
                        Console.WriteLine("Enter award ID");
                        var awDelId = Console.ReadLine();
                        int numAwDelId;
                        if (int.TryParse(awDelId, out numAwDelId))
                        {
                            awLogic.DeleteAward(numAwDelId);
                        }
                        else
                        {
                            Console.WriteLine("ID is NaN");
                        }
                        awLogic.DeleteAward(numAwDelId);
                        break;
                    case "6":
                        var awards = awLogic.DisplayAwards();
                        foreach (var item in awards)
                        {
                            Console.WriteLine(item.Id);
                            Console.WriteLine(item.Name);
                            Console.WriteLine();
                        }
                        break;
                    case "7":
                        int usToAwNum;
                        int awToAwNum;
                        Console.WriteLine("Enter user ID");
                        string usToAw = Console.ReadLine();
                        Console.WriteLine("Enter award ID");
                        string awToAw = Console.ReadLine();
                        if (int.TryParse(usToAw, out usToAwNum) && int.TryParse(awToAw, out awToAwNum))
                        {
                            awLogic.Reward(usToAwNum, awToAwNum);
                        }
                        else
                        {
                            Console.WriteLine("ID is NaN");
                        }
                        break;
                    case "8":
                        Console.WriteLine("Enter user ID");
                        string dispAwId = Console.ReadLine();
                        int dispAwIdNum;
                        List<Award> result = new List<Award>();
                        if (int.TryParse(dispAwId, out dispAwIdNum))
                        {
                            result = awLogic.DisplayUserAwards(dispAwIdNum);
                        }
                        foreach (var item in result)
                        {
                            Console.WriteLine(item.Name);
                            Console.WriteLine(item.Id);
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
