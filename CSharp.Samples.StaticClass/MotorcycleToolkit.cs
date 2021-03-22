using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Samples.StaticClass
{
    class MotorcycleToolkit
    {
        public static Guid VinNUmber => Guid.NewGuid();

        static MotorcycleToolkit()
        {
            Console.WriteLine("Static ctor here");
        }

        public MotorcycleToolkit()
        {
            Console.WriteLine("Default ctor here");
        }
    }
}
