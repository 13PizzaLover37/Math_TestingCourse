using ModulesForTesting.Modules.CustomerModule;

namespace ModulesForTesting.Modules.ProductModule
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public double GetPrice(Customer customer)
        {
            if (customer.IsPlatinum) return Price * 0.8;

            return Price;
        }
    }
}
