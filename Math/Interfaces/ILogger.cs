using ModulesForTesting.Modules.CustomerModule;

namespace ModulesForTesting.Interfaces
{
    public interface ILogger
    {
        void Message(string message);
        bool LogToDb(string message);
        bool LogBalanceAfterWithdraw(int balanceAfterWithdraw);
        string MessageWithReturnsStr(string message);

        bool MessageWithOutString(string message, out string response);
        bool MessageWithRefObj(ref Customer customer);
    }
}
