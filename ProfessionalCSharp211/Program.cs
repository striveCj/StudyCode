using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProfessionalCSharp211
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static void ParallelFor()
        {
            ParallelLoopResult result = Parallel.For(0, 10, i =>
              {
                  Console.WriteLine($"S{i}");
                  Task.Delay(10).Wait();
                  Console.WriteLine($"E{i}");
              });

            Console.WriteLine($"Is completed{result.IsCompleted}");
        }

        public static void ParallelForWithAsync()
        {
            ParallelLoopResult result = Parallel.For(0, 10, async i =>
            {
                Console.WriteLine($"S{i}");
                await Task.Delay(10);
                Console.WriteLine($"E{i}");
            });
            Console.WriteLine(result.IsCompleted);
        }

        public static void StopParallelForEarly()
        {
            ParallelLoopResult result = Parallel.For(0, 40, (int i, ParallelLoopState pls) =>
                {
                    Console.WriteLine();
                    if (i>12)
                    {
                        pls.Break();
                        Console.WriteLine(i);
                    }
                    Task.Delay(10).Wait();
                    Console.WriteLine();
                });
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void ParallerForEach()
        {
            string[] data = { "0", "1", "2" };
            ParallelLoopResult result = Parallel.ForEach<string>(data, a =>
            {
                Console.WriteLine(a);
            });
        }

        public static void ParallelInvoke()
        {
            Parallel.Invoke(Foo,Bar);
        }
        public static void Foo()
        {
            Console.WriteLine("Foo");
        }

        public static void Bar()
        {
            Console.WriteLine("bar");
        }

        public static void TaskMethod(object o)
        {
            Console.WriteLine(o?.ToString());
        }

        private static object s_loglock = new object();

        public static void Log(string title)
        {
            lock (s_loglock)
            {
                Console.WriteLine(title);
                Console.WriteLine(Task.CurrentId?.ToString());
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);
                Console.WriteLine(Thread.CurrentThread.IsBackground);
                Console.WriteLine();
            }
        }

        public void TasksUsingThreadPool()
        {
            var tf = new TaskFactory();
            Task t1 = tf.StartNew(TaskMethod, "using a task factory");
            Task t2 = Task.Factory.StartNew(TaskMethod, "factory via a task");
            var t3 = new Task(TaskMethod, "using a Task constructor and Start");
            t3.Start();
            Task t4 = Task.Run(() => TaskMethod("using the Run method"));
        }

        private static void RunSynchronousTask()
        {
            TaskMethod("Just The Main thread");
            var t1 = new Task(TaskMethod, "run sync");
            t1.RunSynchronously();
        }

        private static void LongRunningTask()
        {
            var t1 = new Task(TaskMethod, "long", TaskCreationOptions.LongRunning);
            t1.Start();
        }

        public static (int Result,int Remainder) TaskWithResult(object division)
        {
            (int x, int y) = ((int x, int y))division;
            int result = x / y;
            int remainder = x % y;
            Console.WriteLine();
            return (result, remainder);
        }

        public static void TaskWithResultDemo()
        {
            var t1 = new Task<(int Result, int Remainder)>(TaskWithResult, (8, 3));
            t1.Start();
            Console.WriteLine(t1.Result);
            t1.Wait();
            Console.WriteLine(t1.Result.Result);
        }

        private static void DoOnFirst()
        {
            Console.WriteLine(Task.CurrentId);
            Task.Delay(3000).Wait();
        }

        private static void DoOnSecond(Task t)
        {
            Console.WriteLine(t.Id);
            Console.WriteLine(Task.CurrentId);
            Task.Delay(3000).Wait();
        }

        public static void ContinuationTasks()
        {
            Task t1 = new Task(DoOnFirst);
            Task t2 = t1.ContinueWith(DoOnSecond);
            Task t3 = t1.ContinueWith(DoOnSecond);
            Task t4 = t2.ContinueWith(DoOnSecond);
            t1.Start();
        }
        public static void ParentAndChild()
        {
            var parent = new Task(ParentTask);
            parent.Start();
            Task.Delay(4000).Wait();
            Console.WriteLine(parent.Status);
            Task.Delay(4000).Wait();
            Console.WriteLine(parent.Status);
        }

        private static void ParentTask()
        {
            Console.WriteLine(Task.CurrentId);
            var child = new Task(ChildTask);
            child.Start();
            Task.Delay(1000).Wait();
            Console.WriteLine("parent started child");
        }

        private static void ChildTask()
        {
            Console.WriteLine("child");
            Task.Delay(5000).Wait();
            Console.WriteLine("child finished");
        }

        public static Task<(IEnumerable<string> data, DateTime retrievedTime)> GetTheRealData() => Task.FromResult((Enumerable.Range(0, 10).Select(x => $"item{x}").AsEnumerable(), DateTime.Now));

        private static DateTime _retrieved;
        private static IEnumerable<string> _cachedDate;
        public static async ValueTask<IEnumerable<string>> GetSomeDataAsync()
        {
            if (_retrieved>= DateTime.Now.AddSeconds(-5))
            {
                Console.WriteLine("data from the cache");
                return await new ValueTask<IEnumerable<string>>(_cachedDate);
            }
            Console.WriteLine("data from the service");
            (_cachedDate, _retrieved) = await GetTheRealData();
            return _cachedDate;
        }

        public static void CancelParallelFor()
        {
            var cts = new CancellationTokenSource();
            cts.Token.Register(() => Console.WriteLine("************ token cancelled"));
            cts.CancelAfter(500);
            try
            {
                ParallelLoopResult result = Parallel.For(0, 100, new ParallelOptions { CancellationToken = cts.Token, }, x =>
                {
                    Console.WriteLine(x);
                    int sum = 0;
                    for (int i = 0; i < 100; i++)
                    {
                        Task.Delay(2).Wait();
                        sum += 1;
                    }
                    Console.WriteLine(x);
                });

            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);；
            }
        }
    }
}
