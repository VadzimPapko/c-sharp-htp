using System;

namespace CSharp.Samples.Delegates.GlobalMotorcycleServiceModule
{
    public delegate void MotoServiceDelegate(int totalDistance);
    
    public class MotorcyleService
    {
        private MotoServiceDelegate _motoServiceDelegate;
        public static int TotalDistance { get; set; }

        public MotorcyleService(MotoServiceDelegate serviceDelegate)
        {
            _motoServiceDelegate = serviceDelegate;

            CheckDistance();
        }

        void CheckDistance()
        {
            if (TotalDistance >= 10_000)
            {
                NotifyAboutService();
            }
        }

        void NotifyAboutService()
        {
            _motoServiceDelegate?.Invoke(TotalDistance);

            //_motoServiceDelegate(TotalDistance);
        }
    }
}
