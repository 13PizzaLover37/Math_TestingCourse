using ModulesForTesting.Modules.CustomerModule;

namespace ModulesForTesting.Interfaces
{
    public interface ILogger
    {
        public int ServerCode { get; set; }
        public string LogType { get; set; }

        void Message(string message);
        bool LogToDb(string message);
        bool LogBalanceAfterWithdraw(int balanceAfterWithdraw);
        string MessageWithReturnsStr(string message);

        bool MessageWithOutString(string message, out string response);
        bool MessageWithRefObj(ref Customer customer);
    }
}
