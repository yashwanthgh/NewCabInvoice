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
            var ride = new List<IRide>
            {
                new Ride(10, 30),
                new Ride(15, 45)
            };
            var actual = invoiceGenerator.CalculateTotalFare(ride);
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}