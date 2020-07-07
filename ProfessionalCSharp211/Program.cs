using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

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
                Console.WriteLine(ex.Message);
            }
        }

        public void CancelTask()
        {
            var cts = new CancellationTokenSource();
            cts.Token.Register(() => Console.WriteLine("********************************************************************"));
            cts.CancelAfter(500);
            Task t1 = Task.Run(() =>
            {
                Console.WriteLine("in task");
                for (int i = 0; i < 20; i++)
                {
                    Task.Delay(100).Wait();
                    CancellationToken token = cts.Token;
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine();
                        token.ThrowIfCancellationRequested();
                        break;
                    }
                }
                Console.WriteLine();
            }, cts.Token);
            try
            {
                t1.Wait();
            }
            catch (AggregateException ex)
            {
                foreach (var item in ex.InnerExceptions)
                {
                    Console.WriteLine(item);

                }
                throw;
            }
        }

        public static void FileTest()
        {
            var processInput = new ActionBlock<string>(s =>
              {
                  Console.WriteLine(s);
              });
            bool exit = false;
            while (!exit)
            {
                string input = Console.ReadLine();
                if (string.Compare(input,"exit",ignoreCase:true)==0)
                {
                    exit = true;
                }
                else
                {
                    processInput.Post(input);
                }
            }
        }

        public static void Producer()
        {
            bool exit = false;
            while (!exit)
            {
                string input = Console.ReadLine();
                if (string.Compare(input,"exit",ignoreCase:true)==0)
                {
                    exit = true;
                }
                else
                {
                    s_buffer.Post(input);
                }
            }
    
        }

        public static IEnumerable<string> GetFileNames(string path)
        {
            foreach (var item in Directory.EnumerateFiles(path,"*.cs"))
            {
                yield return item;
            }
        }

        public static IEnumerable<string> LoadLines(IEnumerable<string> fileNames)
        {
            foreach (var item in fileNames)
            {
                using (FileStream stream=File.OpenRead(item))
                {
                    var reader = new StreamReader(stream);
                    string line = null;
                    while ((line=reader.ReadLine())!=null)
                    {
                        yield return line;
                    }
                }
            }
        }

        public static IEnumerable<string> GetWords(IEnumerable<string> lines)
        {
            foreach (var item in lines)
            {
                string[] words = item.Split(' ', ';', '(', ')', '{', '}', '.', ',');
                foreach (var word in words)
                {
                    if (!string.IsNullOrEmpty(word))
                    {
                        yield return word;
                    }
                }
            }
        }

        public static ITargetBlock<string> SetupPopeline()
        {
            var fileNamesForPath = new TransformBlock<string, IEnumerable<string>>(path => GetFileNames(path));

            var lines = new TransformBlock<IEnumerable<string>, IEnumerable<string>>(fileNames => LodLines(fileNames));

            var words = new TransformBlock<IEnumerable<string>, IEnumerable<string>>(lines2 => GetWords(lines2));

            var display = new ActionBlock<IEnumerable<string>>(coll =>
            {
                foreach (var s in coll)
                {
                    Console.WriteLine(s);
                }
            });

            fileNamesForPath.LinkTo(lines);
            words.LinkTo(display);
            return fileNamesForPath;
        }

        private static void ThreadingTimer()
        {
            void TimeAction(object O)=>Console.WriteLine($"{DateTime.Now}:T");

            using (var t1=new Timer(TimeAction , null, TimeSpan.FromSeconds(2),TimeSpan.FromSeconds(3)))
            {
                Task.Delay(15000).Wait();
            }
        }

        public class StateObject
        {
            private int _state = 5;
            public void ChangeState(int loop)
            {
                if (_state==5)
                {
                    _state++;
                    if (_state!=6)
                    {
                        Console.WriteLine($"Race condition occured after{loop} loopd");
                        Trace.Fail("race condition");
                    }
                }
                _state = 5;
            }
        }

        public class SampleTask
        {
            public void RaceCondition(object o)
            {
                Trace.Assert(o is StateObject, "o must be of type stateobject");
                StateObject state = o as StateObject;
                int i = 0;
                while (true)
                {
                    lock (state)
                    {
                        state.ChangeState(i++);
                    }
                }
            }
        }

        public class StateObject1
        {
            private int _state = 5;
            private object _sync = new object();
            public void ChangeState(int loop)
            {
                lock (_sync)
                {
                    if (_state==5)
                    {
                        _state++;
                        if (_state!=6)
                        {
                            Console.WriteLine(loop);
                            Trace.Fail($"{loop}");
                        }
                        _state = 5;
                    }
                }
            }
        }

        public void RaceConditions()
        {
            var state = new StateObject();
            for (int i = 0; i < 2; i++)
            {
                Task.Run(() => new SampleTask().RaceCondition(state));
            }
        }

        public class SampleTask1
        {
            private StateObject _s1;
            private StateObject _s2;
            public SampleTask1(StateObject s1,StateObject s2)
            {
                _s1 = s1;
                _s2 = s2;
            }

            public void Deadlock1()
            {
                int i = 0;
                while (true)
                {
                    lock (_s1)
                    {
                        lock (_s2)
                        {
                            _s1.ChangeState(i);
                            _s2.ChangeState(i++);
                            Console.WriteLine(i);
                        }
                    }
                }
            }

            public void Deadlock2()
            {
                int i = 0;
                while (true)
                {
                    lock (_s2)
                    {
                        lock (_s1)
                        {
                            _s1.ChangeState(i);
                            _s2.ChangeState(i++);
                            Console.WriteLine(i);
                        }
                    }
                }
            }

            public class SharedState
            {
                public int State { get; set; }
            }

            public class Job
            {
                private SharedState _sharedState;
                public Job(SharedState sharedState)
                {
                    _sharedState = sharedState;
                }

                public void DoTheJob()
                {
                    for (int i = 0; i < 50000; i++)
                    {
                        _sharedState.State += 1;
                    }
                }
            }
        }

        public class SharedState {
            private int _state = 0;
            private object _syncRoot = new object();
            public int State => _state;
            public int IncrementState()
            {
                lock (_syncRoot)
                {
                    return ++_state;
                }
            }
        }

        public class SharedState1
        {
            public int State { get; set; }
        }

        public class Job
        {
            private SharedState1 _sharedState;
            public Job(SharedState1 sharedState)
            {
                _sharedState = sharedState;
            }

            public void DoTheJob()
            {
                for (int i = 0; i < 50000; i++)
                {
                    _sharedState.State += 2;
                }
            }
        }

        public class Dome
        {
            public void DoThis()
            {
                lock (this)
                {

                }
            }
            public void DoThat()
            {
                lock (this)
                {

                }
            }

            private object _syncRoot = new object();

            public void DoThis2()
            {
                lock (_syncRoot)
                {

                }
            }
            public void DoThat2()
            {
                lock (_syncRoot)
                {

                }
            }


        }

        public class Demo
        {
            public virtual bool IsSynchronized => false;

            public static Demo Synchroized(Demo d)
            {
                if (!d.IsSynchronized)
                {
                    return new SynchronizedDemo(d);
                }
                return d;
            }

            public virtual void DoThis() { }

            public virtual void DoThat() { }
            public class SynchronizedDemo : Demo
            {
                private object _synchRoot = new object();
                private Demo _d;
                public SynchronizedDemo(Demo d)
                {
                    _d = d;
                }
                public override bool IsSynchronized => true;

                public override void DoThis()
                {
                    lock (_synchRoot)
                    {
                        _d.DoThis();
                    }
                }

                public override void DoThat()
                {
                    lock (_synchRoot)
                    {
                        _d.DoThat();
                    }
                }

            
               

            }
        }
        public void Mutex()
        {
            bool mutexCreated;
            var mutex = new Mutex(false, "a", out mutexCreated);
            if (!mutexCreated)
            {
                Console.WriteLine("You can only statrt one instace");
                return;
            }
        }
    }

}
