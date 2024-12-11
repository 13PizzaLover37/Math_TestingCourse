namespace Math
{
    public class Customer
    {
        public int Discount { get; set; } = 15;
        public string CustomerFullName(string FirstName, string LastName)
        {
            Discount = 20;
            return $"{FirstName} {LastName}";
        }
    }
}
