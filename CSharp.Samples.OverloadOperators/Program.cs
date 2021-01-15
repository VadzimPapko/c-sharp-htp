using System;

namespace CSharp.Samples.OverloadOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            Motorcycle motorcycle1 = new Motorcycle();
            motorcycle1.Id = Guid.NewGuid();
            Motorcycle motorcycle2 = new Motorcycle();
            Motorcycle motorcycle3 = motorcycle1;

            Motorcycle[] motorcycles = motorcycle1 + motorcycle2;
            Motorcycle motorcycle = new Motorcycle();
            var moto = motorcycle + 1000;

            Console.WriteLine(motorcycle1.Equals(motorcycle2));
            Console.WriteLine(motorcycle1.Equals(motorcycle3));
            Console.WriteLine(motorcycle.Equals(moto));

            Console.WriteLine("===========================");
            Console.WriteLine(motorcycle1 == motorcycle2);
            Console.WriteLine(motorcycle1 == motorcycle);
        }
        
    }

    class Motorcycle 
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        
        public int Odometer { get; set; }

        public static Motorcycle[] operator + (Motorcycle moto1, Motorcycle moto2) 
        {
            return new Motorcycle[]{moto1, moto2 };
        }

        public static Motorcycle operator +(Motorcycle moto, int number)
        {
            moto.Odometer += number;
            return moto;
        }

        public static bool operator ==(Motorcycle motorcycle1, Motorcycle motorcycle2)
        {
            return motorcycle1.Id.Equals(motorcycle2.Id);
        }

        public static bool operator !=(Motorcycle motorcycle1, Motorcycle motorcycle2)
        {
            return !motorcycle1.Id.Equals(motorcycle2.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            var moto = obj as Motorcycle;
            if (this.Id.Equals(moto.Id)) return true;

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
