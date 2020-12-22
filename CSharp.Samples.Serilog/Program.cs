using System;
using Serilog;

namespace CSharp.Samples.Serilog
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs\\myapp.txt", rollingInterval: RollingInterval.Hour)
                .CreateLogger();
            
            
            Log.Information("Hello Logger");

            int a = 10, b = 0;

            try
            {
                Log.Debug("Dividing {A} by {B}", a,b);
                Console.WriteLine(a / b);
            }
            catch (Exception e)
            {
                Log.Error(e, "Something went wrong");
            }
        }
    }
}