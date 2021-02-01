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
            Sample6();
        }

        static void Sample1()
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            Thread thread = new Thread(_ =>
            {
                List<object> collectionY = new List<object>();
                for (int i = 0; i < 1_000_000; i++)
                {
                    Console.Write("Y");
                    collectionY.Add(new { Name = "Y", Number = long.MaxValue });
                }
            });

            thread.Start();
            //thread.Join();

            //List<object> collectionY = new List<object>();
            //for (int i = 0; i < 1_000_000; i++) 
            //{
            //    Console.Write("Y");
            //    collectionY.Add(new { Name = "Y", Number = long.MaxValue });
            //}

            List<object> collectionX = new List<object>();
            for (int i = 0; i < 1_000_000; i++)
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
    }
}
