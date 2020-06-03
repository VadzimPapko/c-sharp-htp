using System;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CSharp.Samples.LogicAndOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started at: " + DateTime.Now.TimeOfDay);

            if (ReturnFalse() && ReturnTrue())
            {
                Console.WriteLine("I am there");
            }

            Console.WriteLine("Finished at: " + DateTime.Now.TimeOfDay);
        }

        static bool ReturnTrue()
        {
            Thread.Sleep(45_000);

            return true;
        }

        static bool ReturnFalse()
        {
            Thread.Sleep(155_000);

            Console.WriteLine("ReturnFalse method finished at: " + DateTime.Now.TimeOfDay);
            return false;
        }
    }
}
