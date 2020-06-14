using System;
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
    }
}
