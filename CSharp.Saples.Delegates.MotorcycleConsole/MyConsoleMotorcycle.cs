using CSharp.Samples.Delegates.GlobalMotorcycleServiceModule;
using System;

namespace CSharp.Saples.Delegates.MotorcycleConsole
{
    sealed class MyConsoleMotorcycle
    {
        public string Model { get; set; }
        public static int Odometer { get; private set; }

        public int DaylieDistance { get; set; }

        public MyConsoleMotorcycle(string name)
        {
            Model = name;
        }

        public void StartEngine()
        {
            Console.WriteLine();
            Console.WriteLine("Engine started.");
        }

        public void Move(int distance)
        {
            DaylieDistance += distance;
            Console.WriteLine($"Move to {distance}km.");
        }

        public void StopEngine()
        {
            Odometer = DaylieDistance;
            MotorcyleService.TotalDistance += DaylieDistance;
            Console.WriteLine("Engine stopped.");
            Console.WriteLine($"TotalDistance: {Odometer}km.");
        }
    }
}
