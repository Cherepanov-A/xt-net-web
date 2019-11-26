using System;

namespace Task2_1_2_4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Round r = new Round(3, 5, 12);
            Console.WriteLine($"Round X = {r.X}");
            Console.WriteLine($"Round Y = {r.Y}");
            Console.WriteLine($"Round Radius = {r.Radius}");
            Console.WriteLine($"Round Area = {r.Area()}");
            Console.WriteLine($"Round length = {r.LengthOfCircle()}");
            Console.WriteLine();
            r.Radius = 10;
            Console.WriteLine($"Round Radius changed to {r.Radius}");
            Console.WriteLine();
            Console.WriteLine($"Round Area = {r.Area()}");
            Console.WriteLine($"Round length = {r.LengthOfCircle()}");
            Console.WriteLine();
            Triangle t = new Triangle(7, 11, 8);
            Console.WriteLine($"Triangle A = {t.A}");
            Console.WriteLine($"Triangle B = {t.B}");
            Console.WriteLine($"Triangle C = {t.C}");
            Console.WriteLine($"Triangle Area = {t.Area()}");
            Console.WriteLine($"Triangle Perimeter = {t.Perimeter()}");
            Console.WriteLine();
            t.B = 10;
            Console.WriteLine($"Triangle B changed to {t.B}");
            Console.WriteLine();
            Console.WriteLine($"Triangle Area = {t.Area()}");
            Console.WriteLine($"Triangle Perimeter = {t.Perimeter()}");
            Console.WriteLine();
            Console.WriteLine("Registering new user Marry");
            Console.WriteLine();
            DateTime dateOfBirth = Convert.ToDateTime("20.02.1989");
            User user = new User("Marry", "May", "Ann", dateOfBirth);
            Console.Write(user.Name + " ");
            Console.Write(user.SecondName + " ");
            Console.WriteLine(user.LastName);
            Console.WriteLine("was born " + user.DateOfBirth.ToShortDateString());
            Console.WriteLine(user.Age + " years old");
            Console.WriteLine();
            Console.WriteLine("Marry and Manie married");
            user.LastName = "Smith";
            Console.WriteLine($"Change Marry's last name to {user.LastName}");
            Console.WriteLine();
            Console.Write(user.Name + " ");
            Console.Write(user.SecondName + " ");
            Console.WriteLine(user.LastName);
            Console.WriteLine("was born " + user.DateOfBirth.ToShortDateString());
            Console.WriteLine(user.Age + " years old");
            Console.WriteLine();
            var rng = new Ring(0,0,3,6);
            Console.WriteLine(rng.LengthOfCircle());
            Console.WriteLine(rng.Area());
            var rnd = new Round(0,0,3);
            Console.WriteLine(rnd.LengthOfCircle());
            Console.WriteLine(rnd.Area());
            Console.ReadLine();
        }
    }
}
