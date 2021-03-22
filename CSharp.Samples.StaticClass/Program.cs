using System;

namespace CSharp.Samples.StaticClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Guid vinNUmber = MotorcycleToolkit.VinNUmber;
            Console.WriteLine($"vin number - {vinNUmber}");

            MotorcycleToolkit motorcycleToolkit = new MotorcycleToolkit();
            MotorcycleToolkit motorcycleToolkit2 = new MotorcycleToolkit();
            MotorcycleToolkit motorcycleToolkit3 = new MotorcycleToolkit();

            Console.WriteLine(Environment.CurrentDirectory);
            Console.WriteLine(Environment.MachineName);
            Console.WriteLine(Environment.OSVersion);
            Console.WriteLine(Environment.ProcessorCount);
        }
    }
}
