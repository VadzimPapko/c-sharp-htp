using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.Samples.GC
{
    class Program
    {
        static GlobalMotorcycleService globalMotoService = new GlobalMotorcycleService();
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //Sample1();

            //string procName = System.Diagnostics
            //    .Process.GetCurrentProcess().ProcessName;

            //using (PerformanceCounter pc = new PerformanceCounter
            //    ("Process", "Private Bytes", procName))
            //    Console.WriteLine(pc.NextValue());

            //Memory Leaks Events
            Console.WriteLine();
            Console.Write("1 Total Heap Size: ");
            Console.WriteLine(System.GC.GetGCMemoryInfo().HeapSizeBytes);

            //Sample2();
            Sample3Using();

            System.Threading.Thread.Sleep(5_000);
            Console.WriteLine();
            Console.Write("2 Total Heap Size: ");
            Console.WriteLine(System.GC.GetGCMemoryInfo().HeapSizeBytes);
            System.Threading.Thread.Sleep(5_000);
            System.GC.Collect();
            System.Threading.Thread.Sleep(10_000);
            Console.WriteLine("3 Total Heap Size: ");
            Console.WriteLine(System.GC.GetGCMemoryInfo().HeapSizeBytes);

            Console.WriteLine("Done");
            Console.ReadKey();
        }

        static void Sample1() 
        {
            byte[] arr = new byte[1000];
            for (int i = 0; i < 10; i++)
            {
                arr = new byte[1000 * i];
                Console.WriteLine($"Iteration {i}");
                ShowGCData(arr);
            }
        }

        static void ShowGCData(object obj = null) 
        {
            Console.Write("Max Generation: ");
            Console.Write(System.GC.MaxGeneration);

            Console.WriteLine();
            Console.Write("Generation for this object: ");
            Console.Write(System.GC.GetGeneration(obj));

            Console.WriteLine();
            Console.Write("Total Allocated Bytes: ");
            Console.Write(System.GC.GetTotalAllocatedBytes());

            Console.WriteLine();
            Console.Write("Total Memory: ");
            Console.Write(System.GC.GetTotalMemory(false));
            
            Console.WriteLine();
            Console.WriteLine();
        }

        static void Sample2() 
        {
            MyConsoleMotorcycle[] motorcycles = Enumerable.Range(0, 10_000)
                .Select(moto => new MyConsoleMotorcycle(globalMotoService)).ToArray();

            //Array.ForEach(motorcycles, c => c.Dispose());
        }

        static void Sample3Using() 
        {
            MyConsoleMotorcycle[] motorcycles = new MyConsoleMotorcycle[10000];

            for (int i = 0; i < motorcycles.Length; i++)
            {
                using (MyConsoleMotorcycle m = new MyConsoleMotorcycle(globalMotoService))
                    motorcycles[i] = m;
            }
        }
    }
}
