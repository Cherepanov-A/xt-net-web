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
        public static int Counter
        {
            get { return counter; }
        }
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
                Data first = new Data();
                first.Path = "null";
                first.TName = 0;
                first.DateOfEvent = DateTime.Now;
                first.TypeOfEvent = "first start";
                log.Add(first);
                writer.Serialize(saveLogStream, log);
                saveLogStream.Close();
            }
        }
        public void LogIt(string FullPath, string ChTyp)
        {
            var openLogStream = File.OpenRead(logPath);
            XmlSerializer reader = new XmlSerializer(typeof(List<Data>));
            log = (List<Data>)reader.Deserialize(openLogStream);
            counter = log.Last().TName;
            Data dt = new Data();
            counter++;
            dt.Path = FullPath;
            dt.TName = counter;
            dt.DateOfEvent = DateTime.Now;
            dt.TypeOfEvent = ChTyp;
            log.Add(dt);
            openLogStream.Close();
            var saveLogStream = File.Create(logPath);
            XmlSerializer writer = new XmlSerializer(typeof(List<Data>));
            writer.Serialize(saveLogStream, log);
            saveLogStream.Close();
        }
    }
}
