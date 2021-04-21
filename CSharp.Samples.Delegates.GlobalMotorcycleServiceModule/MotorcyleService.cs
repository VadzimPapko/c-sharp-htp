using System;

namespace CSharp.Samples.Delegates.GlobalMotorcycleServiceModule
{
    public delegate void MotoServiceDelegate(int totalDistance);

    

    public class MotorcyleService
    {
        //EventHandler
        public static event EventHandler<ServiceLimitAchievedEventArgs> ServiceLimitAchieved;

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

                //OnServiceLimitAchieved(new ServiceLimitAchievedEventArgs(TotalDistance));
            }
        }

        void NotifyAboutService()
        {
            _motoServiceDelegate?.Invoke(TotalDistance);

            //_motoServiceDelegate(TotalDistance);
        }

        /// <summary>
        /// For the EventHandler Sample
        /// </summary>
        /// <param name="eventArgs"></param>
        protected virtual void OnServiceLimitAchieved(ServiceLimitAchievedEventArgs eventArgs)
        {
            ServiceLimitAchieved?.Invoke(this, eventArgs);
        }
    }
}
