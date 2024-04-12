using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCabInvoice
{
    public class Invoice
    {
        public int TotalRides { get; set; }
        public double TotalFare { get; set; }
        public double AverageFarePerRide { get; set; }
    }

    public class Ride(double distance, double duration, bool isPremium) : IRide
    {
        public double Distance { get; } = distance;
        public double Duration { get; } = duration;
        public bool IsPremium { get; } = isPremium;
    }
}
