using ModulesForTesting.Interfaces;

namespace ModulesForTesting.Modules.BankModule
{
    public class Logger : ILogger
    {
        public bool LogBalanceAfterWithdraw(int balanceAfterWithdraw)
        {
            throw new NotImplementedException();
        }

        public bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal)
        {
            if (balanceAfterWithdrawal >= 0)
            {
                Console.WriteLine("Success");
                return true;
            }

            Console.WriteLine("Failure");
            return false;
        }

        public bool LogToDb(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public string MessageWithReturnsStr(string message)
        {
            Console.WriteLine(message);
            return message;
        }
    }
}
