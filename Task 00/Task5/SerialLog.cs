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
        private static string _logPath;
        private static string _backupDir;
        public static int Counter { get; private set; }
        public static string  BackupDir { get=>_backupDir;}

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public SerialLog()
        {
            string logPath;
            string backupDir;

            if ((File.Exists(Directory.GetCurrentDirectory() + "\\config.xml")))
            {
                Path pathes = new Path();
                using (var cfgStream = File.OpenRead(Directory.GetCurrentDirectory() + "\\config.xml"))
                {
                    XmlSerializer cfgReader = new XmlSerializer(typeof(Path));
                    Path tmpPathes = (Path)cfgReader.Deserialize(cfgStream);
                    pathes = tmpPathes;
                }
                backupDir = pathes.BackupPath;
                logPath = pathes.LogPath;
            }
            else
            {
                Path pathes = new Path();
                backupDir = @"C:\Backup";
                logPath = @"C:\Backup\sLog.xml";
                using (var cfgStream = File.Create(Directory.GetCurrentDirectory() + "\\config.xml"))
                {
                    XmlSerializer cfgWriter = new XmlSerializer(typeof(Path));
                    cfgWriter.Serialize(cfgStream, pathes);
                }                
            }
            _logPath = logPath;
            _backupDir = backupDir;
        }
        private static void LogCheck(string logPath)
        {
            if (File.Exists(logPath))
            {
                var openLogStream = File.OpenRead(logPath);
                XmlSerializer reader = new XmlSerializer(typeof(List<Data>));
                _log = (List<Data>)reader.Deserialize(openLogStream);
                Counter = _log.Last().TName;
                openLogStream.Close();
            }
            else
            {                
                var saveLogStream = File.Create(logPath);
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
            LogCheck(_logPath);
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
