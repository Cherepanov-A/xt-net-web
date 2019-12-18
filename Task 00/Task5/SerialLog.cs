using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task5
{
    class SerialLog : ILogger
    {
        private static int counter;
        private static List<Data> log;
        private static string logPath = @"D:\Backup\sLog.xml";
        public static int Counter => counter;

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public SerialLog()
        {
            if (File.Exists(logPath))
            {
                var openLogStream = File.OpenRead(logPath);
                XmlSerializer reader = new XmlSerializer(typeof(List<Data>));
                log = (List<Data>)reader.Deserialize(openLogStream);
                counter = log.Last().TName;
                openLogStream.Close();
            }
            else
            {
                var saveLogStream = File.Create(logPath);
                XmlSerializer writer = new XmlSerializer(typeof(List<Data>));
                log = new List<Data>();
                Data first = new Data
                {
                    Path = "null",
                    TName = 0,
                    DateOfEvent = DateTime.Now,
                    TypeOfEvent = "first start",
                    Name = "starter"
                };
                log.Add(first);
                writer.Serialize(saveLogStream, log);
                saveLogStream.Close();
            }
        }
        public void LogIt(string fullPath, string chTyp, string name)
        {
            var openLogStream = File.OpenRead(logPath);
            XmlSerializer reader = new XmlSerializer(typeof(List<Data>));
            log = (List<Data>)reader.Deserialize(openLogStream);
            counter = log.Last().TName;
            Data dt = new Data();
            counter++;
            dt.Path = fullPath;
            dt.TName = counter;
            dt.DateOfEvent = DateTime.Now;
            dt.TypeOfEvent = chTyp;
            dt.Name = name;
            log.Add(dt);
            openLogStream.Close();
            var saveLogStream = File.Create(logPath);
            XmlSerializer writer = new XmlSerializer(typeof(List<Data>));
            writer.Serialize(saveLogStream, log);
            saveLogStream.Close();
        }
    }
}
