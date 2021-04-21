#define Debug
using System;
using System.Diagnostics;
using System.Reflection;

namespace AttributeSample
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Obsolete Attribute sample
            //var model = MotorCycle.GetModel();
            #endregion

            MotorCycle.GetVinNumber();
            return;
            #region Custom Attribute Sample

            MotorCycle moto = new MotorCycle();
            moto.Vin = "12345678";
            moto.Name = "Hornet";

            Type motoType = moto.GetType();
            foreach (PropertyInfo pi in motoType.GetProperties())
            {
                foreach (Attribute attribute in pi.GetCustomAttributes())
                {
                    MaxLengthAttribute lengthAttribute = attribute as MaxLengthAttribute;

                    if (lengthAttribute == null) continue;

                    switch (pi.Name)
                    {
                        case nameof(MotorCycle.Name):
                            if (moto.Name.Length > lengthAttribute.Length)
                            {
                                throw new Exception($"Name {moto.Name} should be less then {lengthAttribute.Length}");
                            }
                            break;

                        case nameof(MotorCycle.Vin):
                            if (moto.Vin.Length > lengthAttribute.Length)
                            {
                                throw new Exception($"Vin {moto.Vin} should be less then {lengthAttribute.Length}");
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            #endregion

            Console.Read();
        }
    }

    class MotorCycle
    {
        public string Model => "Honda";

        [MaxLength(Length = 10)]
        public string Name { get; set; }

        [MaxLength(Length = 7)]
        public string Vin { get; set; }

        [Obsolete("Do not use GetModel method, use Model prop instead", true)]
        internal static string GetModel()
        {
            return "Honda";
        }

        [Conditional("DEBUG")]
        internal static void GetVinNumber()
        {
            Console.WriteLine(1234);
        }
    }
}