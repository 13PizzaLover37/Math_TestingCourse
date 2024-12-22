using ModulesForTesting.Interfaces;

namespace ModulesForTesting.Modules.BankModule
{
    public class BankAccount
    {
        public int Balance { get; set; }
        private readonly ILogger _logger;
        public BankAccount(ILogger logger) => this._logger = logger;

        public bool Deposit(int amount)
        {
            _logger.Message("Deposit invoked");
            Balance += amount;
            return true;
        }

        public bool Withdraw(int amount)
        {
            if (amount > Balance) return false;

            Balance -= amount;
            return true;
        }

        public int GetBalance() => Balance;
    }
}
