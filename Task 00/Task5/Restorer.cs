using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Task5
{
    internal class Restorer
    {
        public static List<Data> Log = new List<Data>();
        private static readonly string logPath = @"D:\Backup\sLog.xml";
        public static void Restore(DateTime rsDate)
        {
            var openLogStream = File.OpenRead(logPath);
            XmlSerializer reader = new XmlSerializer(typeof(List<Data>));
            Log = (List<Data>)reader.Deserialize(openLogStream);
            IEnumerable<int> names = new List<int>();
            names = from data in Log
                    where data.DateOfEvent <= rsDate
                    where data.TypeOfEvent == "Changed" | data.TypeOfEvent == "Renamed" | data.TypeOfEvent == "Created"
                    select data.TName;
            var namesArr = names.ToArray();
            var restoreList = new List<Data>();
            var restoreListFiltered = new List<Data>();
            for (int i = 0; i < Log.Count; i++)
            {
                foreach (var name in namesArr)
                {
                    if (Log[i].TName == name)
                    {
                        restoreList.Add(Log[i]);
                    }
                }
            }
            if (restoreList.Count > 0)
            {
                RstListCreate(restoreList, restoreListFiltered);
            }
            if (restoreListFiltered.Count > 0)
            {
                string rstPath = Directory.GetCurrentDirectory() + "\\restored";
                Directory.Delete(rstPath);
                Directory.CreateDirectory(rstPath);
                foreach (var el in restoreListFiltered)
                {
                    File.Copy(@"D:\backup\" + el.TName, rstPath + "\\" + el.Name, true);
                    //Console.WriteLine(el.TName);
                    //Console.WriteLine(el.DateOfEvent);
                    //Console.WriteLine(el.Path);
                    //Console.WriteLine(el.TypeOfEvent);
                    //Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No elements found");
            }
            Console.ReadLine();
        }
        private static void RstListCreate(List<Data> restoreList, List<Data> restoreListFiltered)
        {
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
        }
    }
}
