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
            double acutal = generator.CalculateFare(ride);
            Assert.That(acutal, Is.EqualTo(expected));
        }
    }
}