using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Xml.Serialization;


namespace Task5
{
    internal class JsonLog : ILogger
    {
        private static List<Data> _log;
        private static string _logPath;
        private static string _backupDir;
        public static int Counter { get; private set; }
        public static string BackupDir { get => _backupDir; }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public JsonLog()
        {
            string logPath;
            string backupDir;
            if ((File.Exists(Directory.GetCurrentDirectory() + "\\config.json")))
            {
                Path pathes = new Path();
                JsonSerializer serializer = new JsonSerializer();
                using (var cfgReader = new StreamReader(Directory.GetCurrentDirectory() + "\\config.json"))
                using (var reader = new JsonTextReader(cfgReader))
                {
                    pathes = serializer.Deserialize<Path>(reader);
                    backupDir = pathes.BackupPath;
                    logPath = pathes.LogPath;
                    reader.Close();
                    cfgReader.Close();
                }
            }
            else
            {
                Path pathes = new Path();
                backupDir = @"C:\Backup";
                logPath = @"C:\Backup\jLog.json";
                JsonSerializer serializer = new JsonSerializer();
                using (var cfgWriter = new StreamWriter(Directory.GetCurrentDirectory() + "\\config.json"))
                using (var writer = new JsonTextWriter(cfgWriter))
                {
                    serializer.Serialize(writer, pathes);
                    writer.Close();
                    cfgWriter.Close();
                }
            }
            _logPath = logPath;
            _backupDir = backupDir;
        }

        private static void LogCheck(string logPath)
        {
            if (File.Exists(logPath))
            {
                JsonSerializer serializer = new JsonSerializer();
                using (var cfgReader = new StreamReader(logPath))
                using (var reader = new JsonTextReader(cfgReader))
                {
                    _log = serializer.Deserialize<List<Data>>(reader);
                    Counter = _log.Last().TName;
                    reader.Close();
                    cfgReader.Close();
                }
            }
            else
            {
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
                JsonSerializer serializer = new JsonSerializer();
                using (var cfgWriter = new StreamWriter(logPath))
                using (var writer = new JsonTextWriter(cfgWriter))
                {
                    serializer.Serialize(writer, _log);
                    writer.Close();
                    cfgWriter.Close();
                }
            }
        }

        public void LogIt(string fullPath, string chTyp, string name)
        {
            LogCheck(_logPath);
            
            JsonSerializer serializer = new JsonSerializer();
            using (var cfgReader = new StreamReader(_logPath))
            using (var reader = new JsonTextReader(cfgReader))
            {
                _log = serializer.Deserialize<List<Data>>(reader);
                Counter = _log.Last().TName;
                reader.Close();
                cfgReader.Close();
            }
            Data dt = new Data();
            Counter++;
            dt.Path = fullPath;
            dt.TName = Counter;
            dt.DateOfEvent = DateTime.Now;
            dt.TypeOfEvent = chTyp;
            dt.Name = name;
            _log.Add(dt);
            File.Create(_logPath);
            using (var cfgWriter = new StreamWriter(_logPath))
            using (var writer = new JsonTextWriter(cfgWriter))
            {
                serializer.Serialize(writer, _log);
                writer.Close();
                cfgWriter.Close();
            }
        }
    }
}



