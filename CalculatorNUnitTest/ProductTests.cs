using ModulesForTesting.Modules.CustomerModule;
using ModulesForTesting.Modules.ProductModule;
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
    }
}
