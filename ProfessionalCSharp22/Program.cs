using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProfessionalCSharp22
{
    class Program
    {
        static void Main(string[] args)
        {

         }
        #region 22.7观察文件的更改

        private static FileSystemWatcher s_watcher;
        public static void WatchFiles(string path,string filter)
        {
            s_watcher = new FileSystemWatcher(path, filter)
            {
                IncludeSubdirectories = true
            };
            s_watcher.Created += OnFileChanged;
            s_watcher.Changed += OnFileChanged;
            s_watcher.Deleted += OnFileChanged;
            s_watcher.Renamed += OnFileChanged;
            s_watcher.EnableRaisingEvents = true;
            Console.WriteLine("Watching file changes...");

        }

        private static void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"file{e.Name}{e.ChangeType}");
        }

        private static void OnFileChanged(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"file{e.OldName}{e.ChangeType}{e.Name}");
        }
        #endregion

        #region 22.8使用内存映射的文件
        private ManualResetEventSlim _mapCreated=new ManualResetEventSlim(initialState:false);
            private  ManualResetEventSlim _dataWrittenEvent=new ManualResetEventSlim(initialState:false);
        private const string MapName = "SampleMap";

        #endregion
    }
}
