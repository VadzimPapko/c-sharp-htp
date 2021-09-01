using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Samples.GC
{
    class MyConsoleMotorcycle : IDisposable
    {
        GlobalMotorcycleService _motorcycleService;
        
        public string Model { get; set; }
        public static int Odometer { get; private set; }
        public int DaylieDistance { get; set; }

        public MyConsoleMotorcycle(GlobalMotorcycleService motorcycleService)
        {
            _motorcycleService = motorcycleService;
            _motorcycleService.ServiceLimitAchieved += _motorcycleService_ServiceLimitAchieved;
        }

        private void _motorcycleService_ServiceLimitAchieved(object sender, EventArgs e)
        {
            //do something
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
            //MotorcyleService.TotalDistance += DaylieDistance;
            Console.WriteLine("Engine stopped.");
            Console.WriteLine($"TotalDistance: {Odometer}km.");
        }

        public void Dispose()
        {
            _motorcycleService.ServiceLimitAchieved -= _motorcycleService_ServiceLimitAchieved;
        }
    }
}
