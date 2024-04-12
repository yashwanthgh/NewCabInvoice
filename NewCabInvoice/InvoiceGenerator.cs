using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCabInvoice
{
   
    public class InvoiceGenerator : IInvoiceGenerator
    {
        public double CalculateFare(IRide ride)
        {
            double costPerKm = ride.IsPremium ? 15 : 10;
            double costPerMinute = ride.IsPremium ? 2 : 1;
            double fare = ride.Distance * costPerKm + ride.Duration * costPerMinute;
            return Math.Max(fare, ride.IsPremium ? 20 : 5);
        }

        public double CalculateTotalFare(IEnumerable<IRide> rides)
        {
            return rides.Sum(ride => CalculateFare(ride));
        }

        public Invoice GenerateInvoice(IEnumerable<IRide> rides)
        {
            double totalFare = CalculateTotalFare(rides);
            int totalRides = rides.Count();
            return new Invoice
            {
                TotalRides = totalRides,
                TotalFare = totalFare,
                AverageFarePerRide = totalFare / totalRides
            };
        }
    }
}
