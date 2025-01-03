namespace ModulesForTesting.Interfaces
{
    public interface ILogger
    {
        void Message(string message);
        bool LogToDb(string message);
        bool LogBalanceAfterWithdraw(int balanceAfterWithdraw);
    }
}
