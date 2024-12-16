using Math;
using NUnit.Framework;

namespace Math
{
    [TestFixture]
    public class CustomerNUnutTests
    {
        private Customer customer = new Customer();
        
        [SetUp]
        public void Setup() => customer = new Customer();

        [Test]
        [TestCase("John", "Smith", ExpectedResult = "John Smith")]
        [TestCase("William", "Scoth", ExpectedResult = "William Scoth")]
        [TestCase("", "", ExpectedResult = " ")]
        public string CustomerFullName_InputTwoString_ReturnFullName(string FirstName, string LastName)
        {
            return customer.CustomerFullName(FirstName, LastName);
        }

        [Test]
        public void CustomerFullName_InputTwoString_ReturnFullName()
        {
            var response = customer.CustomerFullName("John", "Smith");

            Assert.That(response, Does.Contain("John Smith"));
            Assert.That(response, Does.Contain("john smith").IgnoreCase);
            Assert.That(response, Does.StartWith("john ").IgnoreCase);
            Assert.That(response, Does.EndWith("Smith"));
            Assert.That(response, Does.Match("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
            
            // or
            // this multiple will allow you to run all of the tests, even if any will be failed
            Assert.Multiple(() =>
            {
                var response = customer.CustomerFullName("John", "Smith");

                Assert.That(response, Does.Contain("John Smith"));
                Assert.That(response, Does.Contain("john smith").IgnoreCase);
                Assert.That(response, Does.StartWith("john ").IgnoreCase);
                Assert.That(response, Does.EndWith("Smith"));
                Assert.That(response, Does.Match("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
            });
        }

        [Test]
        public void DiscountCheck_DefaultCustomer_ReturnDiscountInRange()
        {
            int result = customer.Discount;
            Assert.That(result, Is.InRange(15,23));
        }

    }
}
