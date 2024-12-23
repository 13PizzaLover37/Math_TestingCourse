using ModulesForTesting.Interfaces;

namespace ModulesForTesting.Modules.CustomerModule
{
    public class Customer :ICustomer
    {
        public int Discount { get; set; } = 15;
        public bool IsPlatinum { get; set; }
        public string CustomerFullName(string FirstName, string LastName)
        {
            Discount = 20;
            return $"{FirstName} {LastName}";
        }
    }
}
