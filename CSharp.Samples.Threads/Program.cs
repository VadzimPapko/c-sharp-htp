using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CSharp.Samples.Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sample1();

            //Sample3();

            //Sample4();

            //Sample5();

            //Foreground & Background Threads
            //Sample7_Foreground_BackgroundThreads();

            //Thread Priority
            //Console.WriteLine(Thread.CurrentThread.Priority);

            //Task Usage
            //Sample8_Task_Usage();

            //Task Result
            //int result = Sample8_Task_Sum(1_000_000_000);
            //Console.WriteLine(result);

            Sample9_Parallel_Invoke();

            //Task Exception 1
            /*
            Task<int> t = new Task<int>(n => Sample8_Task_Sum((int)n), 1_000_000_000);
            Thread.Sleep(5_000);
            Console.WriteLine("Ok. Running Sum");
            t.Start();

            //var result = t.Result;
            try
            {
                var result = t.Result;
                Console.WriteLine(t.Result);
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("Task canceled");
            }
            finally
            {
                Console.WriteLine(t.Status);
            }
            */

            /*
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(3_000);

            Task<int> t = new Task<int>(() => Sample8_Task_Sum(cts.Token, 1000));
            t.Start();
            //Thread.Sleep(10_000);
            //cts.Cancel();

            try
            {
                Console.WriteLine($"Result is {t.Result}");
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("Task status: " + t.Status);
            }
            
            */

            /*
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            //Thread.Sleep(10_000);

            Thread thread = new Thread(delegate () { Thread.Sleep(10_000); });
            thread.Start();
            Thread.Sleep(10_000);

            stopwatch.Stop();
            Console.WriteLine($"Elapsed time - {stopwatch.ElapsedMilliseconds}");
            */

            //Closure
            //Sample2();

            //Exception
            //Sample3();

            //Background Thread
            //Sample4();

            //Task
            //Sample5();

            //Task Exception
            //Sample6();
        }

        static void Sample1()
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            Thread thread = new Thread(_ =>
            {
                List<object> collectionY = new List<object>();
                for (int i = 0; i < 100_000; i++)
                {
                    Console.Write("Y");
                    collectionY.Add(new { Name = "Y", Number = long.MaxValue });
                }
            });

            thread.Start();
            //thread.Join();

            List<object> collectionY = new List<object>();
            for (int i = 0; i < 100_000; i++)
            {
                Console.Write("Y");
                collectionY.Add(new { Name = "Y", Number = long.MaxValue });
            }

            List<object> collectionX = new List<object>();
            for (int i = 0; i < 100_000; i++)
            {
                Console.Write("X");
                collectionX.Add(new { Name = "X", Number = long.MaxValue });
            }

            stopwatch.Stop();
            Console.WriteLine();
            Console.WriteLine($"Elapsed time - {stopwatch.ElapsedMilliseconds}");
        }

        /// <summary>
        /// Closure
        /// </summary>
        static void Sample2()
        {
            for (int i = 0; i < 10; i++)
            {
                //Each iterator has own value i in stack
                //int local = i;
                //new Thread(() => Console.Write(local)).Start();

                new Thread(() => Console.Write(i)).Start();
            }
        }

        /// <summary>
        /// Exceptions
        /// </summary>
        static void Sample3()
        {
            try
            {
                new Thread(Go).Start();
            }
            catch (Exception)
            {
                //Never be there
                Console.WriteLine("We got an Exception");
            }

            Console.WriteLine("Done");
            Console.ReadLine();
        }

        private static void Go(object obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Background Threads
        /// </summary>
        static void Sample4()
        {
            Thread worker = new Thread(() => Console.ReadLine());
            Console.WriteLine(worker.IsBackground);
            worker.Start();
        }

        /// <summary>
        /// Task (first time in .NET Framework 4.0)
        /// </summary>
        static void Sample5()
        {
            //base call - send Action
            //using threads from the Thread Pool
            Task.Run(() => Console.WriteLine("Simple Task"));
            //Console.ReadLine();

            //Status and wait;
            Task task = Task.Run(() =>
            {
                Thread.Sleep(2_000);
                Console.WriteLine("Task there");
            });

            Console.WriteLine(task.IsCompleted);
            task.Wait();
            Console.WriteLine(task.IsCompleted);

            //Task<TResult>
            Task<int> task1 = Task.Run(() => { Console.WriteLine("Simple Task"); return 1000; });

            int result = task1.Result;
        }

        /// <summary>
        /// Task Exception
        /// </summary>
        static void Sample6()
        {
            Task task = Task.Run(() => { throw null; });

            //task.IsFaulted;
            //task.IsCanceled;
            try
            {
                task.Wait();
            }
            catch (AggregateException ex)
            {
                if (ex.InnerException is NullReferenceException)
                    Console.WriteLine("Null Reference Exception!");
                else
                    throw;
            }
        }

        static void Sample7_Foreground_BackgroundThreads()
        {
            Thread thread = new Thread(Worker); //foregound by default

            //thread.IsBackground = true; //do not sleep 10 secs

            thread.Start();

            //Thread.Sleep(100_000);
            Console.WriteLine("Returning from Main");
        }

        private static void Worker() 
        {
            //Thread.Sleep(1000_000); //Demonstrate Explorer Manager + Spy++
            Thread.Sleep(10_000);
            Console.WriteLine("Returning from Worker");
        }

        public static void Sample8_Task_Usage() 
        {
            Task task = new Task(Worker);
            task.Start();
            //task.Wait();

            //or

            Task.Run(() => Console.WriteLine("Hey guys!")).Wait();
        }

        public static int Sample8_Task_Sum(int number) 
        {
            int sum = default;

            for (; number > 0 ; number--)
            {
                checked { sum += number; }
            }

            return sum;
        }

        public static int Sample8_Task_Sum(CancellationToken ct, int number)
        {
            Thread.Sleep(20_000);

            if (ct.IsCancellationRequested)
            {
                ct.ThrowIfCancellationRequested();
            }

            return number;
        }

        public static void Sample9_Parallel_Invoke()
        {
            System.Diagnostics.Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //Sync calls
            //DoSomething(3_000);
            //DoSomething(5_000);
            //DoSomething(10_000);

            //Parallel calls
            Parallel.Invoke
            (
                () => DoSomething(3_000),
                () => DoSomething(5_000),
                () => DoSomething(10_000)
            );

            stopwatch.Stop();
            Console.WriteLine("Total - " + stopwatch.ElapsedMilliseconds + " ms");
        }

        private static void DoSomething(int time) 
        {
            Console.WriteLine("Runnning " + time + "ms");
            Thread.Sleep(time);
        }
    }
}
