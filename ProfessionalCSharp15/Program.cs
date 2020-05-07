﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProfessionalCSharp15
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SynchronizedAPI();
            AsynchronousPattern();
            EventBasedAsyncPattern();
            await TaskBasedAsyncPatternAsync();
            Console.ReadLine();
        }

        private const string url = "http://www.cninnovation.com";
        private static void SynchronizedAPI()
        {
            Console.WriteLine(nameof(SynchronizedAPI));
            using (var client = new WebClient())
            {
                string content = client.DownloadString(url);
                Console.WriteLine(content.Substring(0, 100));
            }
            Console.WriteLine();
        }

        private static void AsynchronousPattern()
        {
            Console.WriteLine(nameof(AsynchronousPattern));
            WebRequest request = WebRequest.Create(url);
            IAsyncResult result = request.BeginGetResponse(ReadResponse, null);
            void ReadResponse(IAsyncResult ar)
            {
                using (WebResponse response = request.EndGetResponse(ar))
                {
                    Stream stream = response.GetResponseStream();
                    var reader = new StreamReader(stream);
                    string content = reader.ReadToEnd();
                    Console.WriteLine(content.Substring(0, 100));
                    Console.WriteLine();
                }
            }
        }

        private static void EventBasedAsyncPattern()
        {
            Console.WriteLine(nameof(EventBasedAsyncPattern));
            using (var client = new WebClient())
            {
                client.DownloadStringCompleted += (sender, e) =>
                {
                    Console.WriteLine(e.Result.Substring(0, 100));
                };
                client.DownloadStringAsync(new Uri(url));
                Console.WriteLine();
            }
        }

        private static async Task TaskBasedAsyncPatternAsync()
        {
            Console.WriteLine(nameof(TaskBasedAsyncPatternAsync));
            using (var client = new WebClient())
            {
                string content = await client.DownloadStringTaskAsync(url);
                Console.WriteLine(content.Substring(0, 100));
                Console.WriteLine();
            }
        }

        public static void TraceThreadAndTask(string info)
        {
            string taskInfo = Task.CurrentId == null ? "no task" : "task" + Task.CurrentId;
            Console.WriteLine($"{info} in thread {Thread.CurrentThread.ManagedThreadId} and {taskInfo}");
        }

        static string Greeting(string name)
        {
            TraceThreadAndTask($"running{nameof(Greeting)}");
            Task.Delay(3000).Wait();
            return $"Hello,{name}";
        }

        static Task<string> GreetingAsync(string name) => Task.Run<string>(() =>
        {
            TraceThreadAndTask($"Rruntime{nameof(GreetingAsync)}");
            return GreetingAsync(name);
        });

        private async static void CallerWithAsync()
        {
            TraceThreadAndTask($"started{nameof(CallerWithAsync)}");
            string result = await GreetingAsync("Stephanie");
            Console.WriteLine(result);
            TraceThreadAndTask($"ended{nameof(CallerWithAsync)}");
        }

        private async static void CallerWithAsync2()
        {
            TraceThreadAndTask($"started{nameof(CallerWithAsync2)}");
            Console.WriteLine(await GreetingAsync("Stephanie"));
            TraceThreadAndTask($"ended{nameof(CallerWithAsync2)}");
        }

        private static void CallerWithAwaiter()
        {
            TraceThreadAndTask($"starting{nameof(CallerWithAwaiter)}");
            TaskAwaiter<string> awaiter = GreetingAsync("Matthias").GetAwaiter();
            awaiter.OnCompleted(OnCompleteAwaiter);
            void OnCompleteAwaiter()
            {
                Console.WriteLine(awaiter.GetResult());
                TraceThreadAndTask($"ended{nameof(CallerWithAwaiter)}");
            }
        }

        private static void CallerWithContinuationTask()
        {
            TraceThreadAndTask($"starting CallerWithContinuationTask");
            var t1 = GreetingAsync("Stephanie");
            t1.ContinueWith(t =>
            {
                string result = t.Result;
                Console.WriteLine(result);
                TraceThreadAndTask("ended CallerWithContinuationTask");
            });

        }
    }
}
