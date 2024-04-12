using NewCabInvoice;
namespace NewCabInvoiceTest
{
    [TestFixture]
    public class InvoiceGeneratorTest
    {
        [Test]
        public void FareCalculator_ReturnTheFareValue()
        {
            double expected = 130;
            IInvoiceGenerator generator = new InvoiceGenerator();
            IRide ride = new Ride(10, 30);
            double actual = generator.CalculateFare(ride);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ForMultipleRides_ReturnTheTotalFare()
        {
            double expected = 325;
            IInvoiceGenerator invoiceGenerator = new InvoiceGenerator();

            var ride = new List<IRide> { new Ride(10, 30), new Ride(15, 45) };

            var actual = invoiceGenerator.CalculateTotalFare(ride);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GenerateInvoice_ForMultipleRides()
        {
            int expectedTotalRides = 2;
            double expectedTotalFare = 325;
            double expectedAverage = 162.5;
            IInvoiceGenerator generator = new InvoiceGenerator();

            var ride = new List<IRide>() { new Ride(10, 30), new Ride(15, 45) };

            var actual = generator.GenerateInvoice(ride);
            Assert.That(actual.TotalRides, Is.EqualTo(expectedTotalRides));
            Assert.That(actual.TotalFare, Is.EqualTo(expectedTotalFare));
            Assert.That(actual.AverageFarePerRide, Is.EqualTo(expectedAverage));    
        }
    }
}