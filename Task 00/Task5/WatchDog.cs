using System;
using System.Collections.Concurrent;
using System.IO;
using System.Security.Permissions;
using System.Threading;

namespace Task5
{
    class WatchDog
    {
        private  readonly string watchDir = Directory.GetCurrentDirectory();
        private  readonly string backupDir;
        private  readonly ConcurrentQueue<FileSystemEventArgs> changeList = new ConcurrentQueue<FileSystemEventArgs>();
        private  readonly ConcurrentQueue<RenamedEventArgs> renameList = new ConcurrentQueue<RenamedEventArgs>();
        private  ILogger Lg = new SerialLog();
        internal WatchDog(string backupDir = @"C:\Backup")
        {
            this.backupDir = backupDir;
        }
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public void Watch()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = watchDir;
            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.Attributes | NotifyFilters.DirectoryName;
            watcher.Renamed += OnRename;
            watcher.Created += OnChange;
            watcher.Deleted += OnChange;
            watcher.Changed += OnChange;
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
        }
        private void OnChange(object sender, FileSystemEventArgs e)
        {
            changeList.Enqueue(e);
        }
        private void OnRename(object sender, RenamedEventArgs e)
        {
            renameList.Enqueue(e);
        }
        internal void FileChangeWork()
        {
            while (true)
            {
                if (changeList.Count > 0)
                {
                    changeList.TryDequeue(out FileSystemEventArgs result);
                    FileSystemEventArgs e = result;
                    switch (e.ChangeType.ToString())
                    {
                        case "Created":
                            {
                                FileHandle(e);
                                break;
                            }
                        case "Deleted":
                            {
                                Lg.LogIt(e.FullPath, e.ChangeType.ToString(), e.Name);
                                Console.WriteLine(e.FullPath + " is " + e.ChangeType);
                                break;
                            }
                        case "Changed":
                            {
                                FileHandle(e);
                                break;
                            }
                    }
                }
                if (renameList.Count > 0)
                {
                    renameList.TryDequeue(out RenamedEventArgs result);
                    RenamedEventArgs e = result;
                    FileHandle(e);
                    Console.WriteLine(e.OldName + " Renamed to " + e.FullPath);
                }
            }
        }
        private static void FileHandle(FileSystemEventArgs e)
        {
            if (File.Exists(e.FullPath))
            {
                Lg.LogIt(e.FullPath, e.ChangeType.ToString(), e.Name);
                int counter = SerialLog.Counter;
                FileCopy(e, $"D:\\Backup\\{counter}");
                Thread.Sleep(5);
                Thread.Sleep(5);
            }
        }
        private static void FileCopy(FileSystemEventArgs e, string filePath)
        {
            if (!Directory.Exists(@"D:\Backup"))
            {
                Directory.CreateDirectory(@"D:\Backup");
                if (File.Exists(e.FullPath))
                {
                    File.Copy(e.FullPath, filePath, true);
                }
            }
            else
            {
                if (File.Exists(e.FullPath))
                {
                    File.Copy(e.FullPath, filePath, true);
                }
            }
            Console.WriteLine(e.FullPath + " is " + e.ChangeType);
        }
    }
}
