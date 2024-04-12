using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCabInvoice
{
    // Acts like veriables
    public interface IRide
    {
        double Distance { get; }
        double Duration { get; }
    }

    // Interface to enforce the method declared inside it on the class which implements
    public interface IInvoiceGenerator
    {
        double CalculateFare(IRide ride);
    }

    // Takes time and distance and assigne it to properties within IRide intreface => we will call this
    public class Ride(double distance, double duration) : IRide
    {
        public double Distance { get; } = distance;
        public double Duration { get; } = duration;
    }
    public class InvoiceGenerator : IInvoiceGenerator
    {
        private const double CostPerKm = 10.0;
        private const double CostPerMinute = 1.0;
        private const double MinimumFare = 5.0;

        public double CalculateFare(IRide ride) // Pass the ride value here 
        {
            double distanceCost = ride.Distance * CostPerKm;
            double timeCost = ride.Duration * CostPerMinute;
            double totalFare = Math.Max(distanceCost + timeCost, MinimumFare);
            return totalFare;
        }

    }
}
