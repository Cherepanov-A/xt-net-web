using System;
using System.IO;
using System.Security.Permissions;
using System.Threading;
using System.Xml.Serialization;

namespace Task5
{
    internal class Program
    {
        private static void Main(string[] args)
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
            bool endOfCycle = true;
            while (endOfCycle)
            {
                Console.WriteLine("Enter restore date in dd.MM.yyyy hh:mm format");
                string date = Console.ReadLine();
                bool success = DateTime.TryParse(date, out var rsDate);
                if (success & rsDate <= DateTime.Now)
                {
                    Restorer.Restore(rsDate);
                    endOfCycle = false;
                }
                Console.WriteLine("Check restore date");
            }
        }
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private static void Backup()
        {
            Console.WriteLine();
            WatchDog watcher = new WatchDog();
            if ((File.Exists(Directory.GetCurrentDirectory() + "\\config.xml")))
            {
                var cfgStream = File.OpenRead(Directory.GetCurrentDirectory() + "\\config.xml");
                XmlSerializer cfgReader = new XmlSerializer(typeof(Path));
                Path pathes = (Path)cfgReader.Deserialize(cfgStream);
                watcher.BackupDir = pathes.BackupPath;
                watcher.LogPath = pathes.LogPath;
            }
            else
            {
                var cfgStream = File.Create(Directory.GetCurrentDirectory() + "\\config.xml");
                XmlSerializer cfgWriter = new XmlSerializer(typeof(string));
                cfgWriter.Serialize(cfgStream, @"C:\Backup\sLog.xml");
            }
            
            
            Thread TList = new Thread(watcher.Watch);
            Thread FWork = new Thread(watcher.FileChangeWork);
            TList.Start();
            FWork.Start();
            Console.WriteLine("Watcher is watching");
        }
    }
}
