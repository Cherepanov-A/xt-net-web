using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task5
{
    class Restorer
    {
        public static List<Data> log = new List<Data>();
        private static string logPath = @"D:\Backup\sLog.xml";
        public static void Restore(string rsDate)
        {
            var openLogStream = File.OpenRead(logPath);
            XmlSerializer reader = new XmlSerializer(typeof(List<Data>));
            log = (List<Data>)reader.Deserialize(openLogStream);
            IEnumerable<int> names = new List<int>();
            names = from data in log
                    where data.DateOfEvent <= Convert.ToDateTime(rsDate)
                    where data.TypeOfEvent == "Changed" | data.TypeOfEvent == "Renamed" | data.TypeOfEvent == "Created"
                    select data.TName;
            var namesArr = names.ToArray();
            var restoreList = new List<Data>();
            var restoreListFiltered = new List<Data>();
            for (int i = 0; i < log.Count; i++)
            {
                foreach (var name in namesArr)
                {
                    if (log[i].TName == name)
                    {
                        restoreList.Add(log[i]);
                    }
                }
            }
            restoreListFiltered.Add(restoreList[0]);
            for (int i = 1; i < restoreList.Count; i++)
            {
                restoreListFiltered.Add(restoreList[i]);
                for (int j = 0; j < restoreListFiltered.Count; j++)
                {
                    if (restoreList[i].Path == restoreListFiltered[j].Path)
                    {
                        if (restoreList[i].DateOfEvent > restoreListFiltered[j].DateOfEvent)
                        {
                            restoreListFiltered.Remove(restoreListFiltered[j]);
                            restoreListFiltered.Add(restoreList[i]);
                        }
                    }
                }
            }
            foreach (var el in restoreListFiltered)
            {
                Console.WriteLine(el.TName);
                Console.WriteLine(el.DateOfEvent);
                Console.WriteLine(el.Path);
                Console.WriteLine(el.TypeOfEvent);
                Console.WriteLine();
            }           
            Console.ReadLine();
        }
    }
}
