using ModulesForTesting.Interfaces;
using ModulesForTesting.Modules.CustomerModule;

namespace ModulesForTesting.Modules.BankModule
{
    public class Logger : ILogger
    {
        public int ServerCode { get; set; }
        public string LogType { get; set; } = string.Empty;

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

        public bool MessageWithOutString(string message, out string response)
        {
            response = "Hello " + message;
            return true;
        }

        public bool MessageWithRefObj(ref Customer customer) => true;

        public string MessageWithReturnsStr(string message)
        {
            Console.WriteLine(message);
            return message;
        }
    }
}
