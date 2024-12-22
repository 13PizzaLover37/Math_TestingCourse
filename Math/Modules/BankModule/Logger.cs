using ModulesForTesting.Interfaces;

namespace ModulesForTesting.Modules.BankModule
{
    public class Logger : ILogger
    {
        public void Message(string message)
        {
            Console.WriteLine(message);
        }
    }
}
