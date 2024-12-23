namespace ModulesForTesting.Interfaces
{
    public interface ICustomer
    {
        int Discount { get; set; }
        bool IsPlatinum { get; set; }

        string CustomerFullName(string FirstName, string LastName);

    }
}
