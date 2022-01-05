using CSharp.Samples.Delegates.GlobalMotorcycleServiceModule;
using System;

namespace CSharp.Saples.Delegates.MotorcycleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //MotoServiceDelegate @delegate = new MotoServiceDelegate(GoToService);
            //MotorcyleService service = new MotorcyleService(@delegate);

            MotorcyleService service = new MotorcyleService();
            MyConsoleMotorcycle myConsoleMotorcycle = new MyConsoleMotorcycle("Honda");
            MotorcyleService.NotifyMotoService += GoToService;

            //Let's Drive
            myConsoleMotorcycle.StartEngine();
            myConsoleMotorcycle.Move(1_000);
            myConsoleMotorcycle.Move(5_000);
            myConsoleMotorcycle.StopEngine();
            myConsoleMotorcycle = null;
            service = null;

            //Let's Drive one more time
            //service = new MotorcyleService(@delegate);
            myConsoleMotorcycle = new MyConsoleMotorcycle("Honda");
            myConsoleMotorcycle.StartEngine();
            myConsoleMotorcycle.Move(1_000);
            myConsoleMotorcycle.Move(5_000);
            myConsoleMotorcycle.StopEngine();
            myConsoleMotorcycle = null;
            service = null;

            //Let's Drive one more time
            //service = new MotorcyleService(@delegate);
            service = new MotorcyleService();
            myConsoleMotorcycle = new MyConsoleMotorcycle("Honda");
            myConsoleMotorcycle.StartEngine();
        }

        static void GoToService(int totalDistance)
        {
            Console.WriteLine($"Time to go moto Service. Current distance of your bike: {totalDistance}");
        }
    }
}
