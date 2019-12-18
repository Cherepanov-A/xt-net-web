using System;
using System.IO;
using System.Security.Permissions;
using System.Threading;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mode selection:");
            Console.WriteLine("1: Backup");
            Console.WriteLine("2: Restoration");
            ConsoleKeyInfo cki = Console.ReadKey();
            Console.WriteLine();
            if (cki.Key == ConsoleKey.D1)
            {
                Backup();
            }
            if (cki.Key == ConsoleKey.D2)
            {
                Restore();
            }
        }
        private static void Restore()
        {
            //Console.WriteLine("Enter restore date");
            string date = "17.12.2019 19:05:00";//Console.ReadLine();
            Restorer.Restore(date);
        }
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private static void Backup()
        {
            if (!File.Exists(@"D:\Backup\log"))
            {
                File.Create(@"D:\Backup\log");
            }           
            WatchDog watcher = new WatchDog();
            Thread TList = new Thread(watcher.Watch);
            Thread FWork = new Thread(watcher.FileChangeWork);
            TList.Start();
            FWork.Start();
            Console.WriteLine("Watcher is watching");
        }
    }
}
