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
        private static List<Data> _log;
        private static string _logPath = @"C:\Backup\sLog.xml";
        public static int Counter { get; private set; }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public SerialLog(string lgPath = @"C:\Backup\sLog.xml")
        {
            _logPath = lgPath;
            if (File.Exists(_logPath))
            {
                var openLogStream = File.OpenRead(_logPath);
                XmlSerializer reader = new XmlSerializer(typeof(List<Data>));
                _log = (List<Data>)reader.Deserialize(openLogStream);
                Counter = _log.Last().TName;
                openLogStream.Close();
            }
            else
            {
                var saveLogStream = File.Create(_logPath);
                XmlSerializer writer = new XmlSerializer(typeof(List<Data>));
                _log = new List<Data>();
                Data first = new Data
                {
                    Path = "null",
                    TName = 0,
                    DateOfEvent = DateTime.Now,
                    TypeOfEvent = "first start",
                    Name = "starter"
                };
                _log.Add(first);
                writer.Serialize(saveLogStream, _log);
                saveLogStream.Close();
            }
        }
        public void LogIt(string fullPath, string chTyp, string name)
        {
            var openLogStream = File.OpenRead(_logPath);
            XmlSerializer reader = new XmlSerializer(typeof(List<Data>));
            _log = (List<Data>)reader.Deserialize(openLogStream);
            Counter = _log.Last().TName;
            Data dt = new Data();
            Counter++;
            dt.Path = fullPath;
            dt.TName = Counter;
            dt.DateOfEvent = DateTime.Now;
            dt.TypeOfEvent = chTyp;
            dt.Name = name;
            _log.Add(dt);
            openLogStream.Close();
            var saveLogStream = File.Create(_logPath);
            XmlSerializer writer = new XmlSerializer(typeof(List<Data>));
            writer.Serialize(saveLogStream, _log);
            saveLogStream.Close();
        }
    }
}
