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
        bool IsPremium { get; }
    }

    // Interface to enforce the method declared inside it on the class which implements
    public interface IInvoiceGenerator
    {
        double CalculateFare(IRide ride); // For one ride
        double CalculateTotalFare(IEnumerable<IRide> rides); // For multiple ride
        Invoice GenerateInvoice(IEnumerable<IRide> rides);
    }

    // To keep track and return them
    public class Invoice
    {
        public int TotalRides { get; set; }
        public double TotalFare { get; set; }
        public double AverageFarePerRide { get; set; }
    }

    // Takes time and distance and assigne it to properties within IRide intreface => we will call this
    public class Ride(double distance, double duration, bool isPremium) : IRide
    {
        public double Distance { get; } = distance;
        public double Duration { get; } = duration;
        public bool IsPremium { get; } = isPremium;
    }
    public class InvoiceGenerator : IInvoiceGenerator
    {
        public double CalculateFare(IRide ride)  // Fare calculation based on whether the ride is premium or not
        {
            double costPerKm = ride.IsPremium ? 15 : 10;
            double costPerMinute = ride.IsPremium ? 2 : 1;
            double fare = ride.Distance * costPerKm + ride.Duration * costPerMinute;
            return Math.Max(fare, ride.IsPremium ? 20 : 5);
        }

        public double CalculateTotalFare(IEnumerable<IRide> rides) // For multiple rides
        {
            double totalFare = 0;
            foreach (var ride in rides)
            {
                totalFare += CalculateFare(ride);
            }
            return totalFare;
        }

        public Invoice GenerateInvoice(IEnumerable<IRide> rides) // To return the TotalRides, Fare and Average Fare
        {
            double totalFare = CalculateTotalFare(rides);
            int totalRides = rides.Count();
            double averageFarePerRide = totalFare / totalRides;

            return new Invoice
            {
                TotalRides = totalRides,
                TotalFare = totalFare,
                AverageFarePerRide = averageFarePerRide
            };
        }

    }
}
