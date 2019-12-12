using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
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

        public void Run()
        {
          
        }

        //使用访问器创建内存映射文件
        private async Task WriterAsync()
        {
            try
            {
                using (MemoryMappedFile mappedFile=MemoryMappedFile.CreateOrOpen(MapName,10000,MemoryMappedFileAccess.ReadWrite))
                {
                    _mapCreated.Set();
                    Console.WriteLine("shared memory segment created");
                    using (MemoryMappedViewAccessor accessor = mappedFile.CreateViewAccessor(0, 10000, MemoryMappedFileAccess.Write))
                    {
                        for (int i = 0,pos=0; i < 100; i++,pos+=4)
                        {
                            accessor.Write(pos,i);
                            Console.WriteLine($"written{i} at position{pos}");
                            await Task.Delay(10);
                        }
                        _dataWrittenEvent.Set();
                        Console.WriteLine("data written");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        private void Reader()
        {
            try
            {
                Console.WriteLine("reader");
                _mapCreated.Wait();
                Console.WriteLine("reader starting");
                using (MemoryMappedFile mappedFile=MemoryMappedFile.OpenExisting(MapName,MemoryMappedFileRights.Read))
                {
                    using (MemoryMappedViewAccessor accessor = mappedFile.CreateViewAccessor(0, 10000, MemoryMappedFileAccess.Read))
                    {
                        _dataWrittenEvent.Wait();
                        Console.WriteLine("reading can start now");
                        for (int i = 0; i < 400; i+=4)
                        {
                            int result = accessor.ReadInt32(i);
                            Console.WriteLine($"reading {result} from position");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
        }

        private async Task ReaderUsingStreams()
        {
            try
            {
                Console.WriteLine("reader");
                _mapCreated.Wait();
                Console.WriteLine("reader starting");
                using (MemoryMappedFile mappedFile=MemoryMappedFile.OpenExisting(MapName,MemoryMappedFileRights.Read))
                {
                    MemoryMappedViewStream stream = mappedFile.CreateViewStream(0, 10000, MemoryMappedFileAccess.Read);
                    using (var reader=new StreamReader(stream))
                    {
                        _dataWrittenEvent.Wait();
                        Console.WriteLine("reading can start now");
                        for (int i = 0; i < 100; i++)
                        {
                            long pos = stream.Position;
                            string s = await reader.ReadLineAsync();
                            Console.WriteLine($"read {s} from {pos}");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
               
            }
        }
        #endregion
    }
}
