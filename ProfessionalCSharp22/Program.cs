﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.IO.Pipes;
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
            Task.Run(() => WriterAsync());
            Task.Run(() => Reader());
            Console.WriteLine("tasks started");
            Console.ReadLine();
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


        #region 使用流创建内存映射文件

        private async Task WriterUsingStreams()
        {
            try
            {
                using (MemoryMappedFile mappedFile = MemoryMappedFile.CreateOrOpen(MapName, 10000, MemoryMappedFileAccess.ReadWrite))
                {
                    _mapCreated.Set();
                    Console.WriteLine("shared memory segment create");
                    MemoryMappedViewStream stream = mappedFile.CreateViewStream(0, 10000, MemoryMappedFileAccess.Write);
                    using (var writer = new StreamWriter(stream))
                    {
                        writer.AutoFlush = true;
                        Console.WriteLine("reading can start now");
                        for (int i = 0; i < 100; i++)
                        {

                            string s = $"some data {i}";
                            Console.WriteLine($"writing{s} at {stream.Position}");
                            await writer.WriteLineAsync(s);
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
                using (MemoryMappedFile mappedFile = MemoryMappedFile.OpenExisting(MapName, MemoryMappedFileRights.Read))
                {
                    MemoryMappedViewStream stream = mappedFile.CreateViewStream(0, 10000, MemoryMappedFileAccess.Read);
                    using (var reader = new StreamReader(stream))
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


        #endregion

        #region 22.9使用管道通性

        #region 22.9.1创建命名管道服务器

        private static void PipesReader(string pipeName)
        {
            try
            {
                using (var pipReader = new NamedPipeServerStream(pipeName, PipeDirection.In))
                {
                    pipReader.WaitForConnection();
                    Console.WriteLine("reader connected");
                    const int BUFFERSIZE = 256;
                    bool completed = false;
                    while (!completed)
                    {
                        byte[] buffer = new byte[BUFFERSIZE];
                        int nRead = pipReader.Read(buffer, 0, BUFFERSIZE);
                        string line = Encoding.UTF8.GetString(buffer, 0, nRead);
                        Console.WriteLine(line);
                        if (line == "bye")
                        {
                            completed = true;
                        }
                    }
                    Console.WriteLine("completed reading");
                    Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


        #endregion

        #region 22.9.2创建命名管道客户端

        public static void PipesWriter(string serverName, string pipeName)
        {
            var pipeWriter = new NamedPipeClientStream(serverName, pipeName, PipeDirection.Out);
            using (var writer = new StreamWriter(pipeWriter))
            {
                pipeWriter.Connect();
                Console.WriteLine("writer connected");
                bool completed = false;
                while (!completed)
                {
                    string input = Console.ReadLine();
                    if (input == "bye") completed = true;
                    Console.WriteLine(input);
                    writer.Flush();

                }
            }
            Console.WriteLine("completed writing");
        }


        #endregion

        #region 22.9.3创建匿名管道

        private string _pipeHandle;
        private ManualResetEventSlim _pipeHandleSet;

        private void Reader2()
        {
            try
            {
                var pipeReader=new AnonymousPipeServerStream(PipeDirection.In,HandleInheritability.None);
                using (var reader=new StreamReader(pipeReader))
                {
                    _pipeHandle = pipeReader.GetClientHandleAsString();
                    Console.WriteLine($"pipe handle:{_pipeHandle}");
                    _pipeHandleSet.Set();
                    bool end = false;
                    while (!end)
                    {
                        string line = reader.ReadLine();
                        Console.WriteLine(line);
                        if (line=="end")
                        {
                            end = true;
                        }
                    }
                    Console.WriteLine("finished reading");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
               
            }
        }


        private void Writer2()
        {
            Console.WriteLine("anonymous pipe writer");
            _pipeHandleSet.Wait();
            var pipeWriter=new AnonymousPipeClientStream(PipeDirection.Out,_pipeHandle);
            using (var writer=new StreamWriter(pipeWriter))
            {
                writer.AutoFlush = true;
                Console.WriteLine("Starting writer");
                for (int i = 0; i < 5; i++)
                {
                    writer.WriteLine($"Message{i}");
                    Task.Delay(500).Wait();
                }
                Console.WriteLine("end");
            }
        }
        #endregion

        #endregion

    }
}
