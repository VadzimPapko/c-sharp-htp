using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Samples.Delegates.GlobalMotorcycleServiceModule
{
    public class ServiceLimitAchievedEventArgs : EventArgs
    {
        public int CurrentOdometr { get; }

        public ServiceLimitAchievedEventArgs(int odometer)
        {
            CurrentOdometr = odometer;
        }
    }
}
