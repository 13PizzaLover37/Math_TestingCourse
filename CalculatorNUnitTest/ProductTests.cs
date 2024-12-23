using ModulesForTesting.Interfaces;
using ModulesForTesting.Modules.CustomerModule;
using ModulesForTesting.Modules.ProductModule;
using Moq;
using NUnit.Framework;

namespace Math
{
    [TestFixture]
    public class ProductTests
    {
        // unit test without mocking
        [Test]
        public void GetProductPrice_PlatinumCustomer_GetPriceWuth20Discount()
        {
            Product product = new Product() { Price = 50 };

            var customer = new Customer() { IsPlatinum = true, Discount = 20 };

            var result = product.GetPrice(customer);

            Assert.That(result, Is.EqualTo(40));
        }

        // unit test with mocking
        [Test]
        public void GetProductPrice_PlatinumCustomer_GetPriceWuth20Discount_With_Mocking()
        {
            // for the mocking I needed to add interface ICustomer, for using mocking
            Product product = new Product() { Price = 50 };

            var mock = new Mock<ICustomer>();
            mock.Setup(el => el.Discount).Returns(20);
            mock.Setup(el => el.IsPlatinum).Returns(true);

            var result = product.GetPrice(mock.Object);

            Assert.That(result, Is.EqualTo(40));
        }
    }
}
