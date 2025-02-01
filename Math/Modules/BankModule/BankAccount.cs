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
            _logger.Message($"Deposit {amount}");
            _logger.ServerCode = 200;
            var temp = _logger.ServerCode;

            Balance += amount;
            return true;
        }

        public bool Withdraw(int amount)
        {
            if (amount > Balance) _logger.LogBalanceAfterWithdraw(Balance - amount);
            
            _logger.LogToDb("Withdraw amount: " + amount.ToString());
            Balance -= amount;
            return _logger.LogBalanceAfterWithdraw(Balance);
        }

        public int GetBalance() => Balance;
    }
}
