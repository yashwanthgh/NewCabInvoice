using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCabInvoice
{
    public interface IRide
    {
        double Distance { get; }
        double Duration { get; }
        bool IsPremium { get; }
    }

    public interface IInvoiceGenerator
    {
        double CalculateFare(IRide ride);
        double CalculateTotalFare(IEnumerable<IRide> rides);
        Invoice GenerateInvoice(IEnumerable<IRide> rides);
    }
}
