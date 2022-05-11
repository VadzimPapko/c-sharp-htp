namespace ReflectionSample
{
    class Motorcycle
    {
        public string Name { get; set; }
        public string Model { get; set; }

        private int _vinNumber = 111;

        int _odometer;
        public int Odometer { get => _odometer; set => _odometer = value; }

        public Motorcycle()
        {
        }

        public Motorcycle(string name)
        {
            Name = name;
        }

        public Motorcycle(System.DateTime created, string name)
        {
        }

        public int GetVinNumber()
        {
            return _vinNumber;
        }

        public override string ToString()
        {
            return $"Motorcycle: {Name}, Model: {Model}, Odometer: {Odometer}, VinNumber: {GetVinNumber()}";
        }

        class TechnicalInfo { };
    }
}
