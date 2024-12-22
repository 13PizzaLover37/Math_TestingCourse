using ModulesForTesting.Interfaces;
using ModulesForTesting.Modules.BankModule;
using Moq;
using NUnit.Framework;

namespace Math
{
    [TestFixture]
    public class BankAccountNUnitTests
    {
        // this is not an unit test, buy integrational, because 
        // in BankAccount class -> Deposit method we have logger, that logs method calling
        
        // if we want to do unit test -> we need to use mocking
        [Test]
        public void BankDeposit_Add100_ReturnTrue_Integrational_Test()
        {
            var _bankAccount = new BankAccount(new Logger());
            var result = _bankAccount.Deposit(100);
            Assert.That(result, Is.True);
            Assert.That(_bankAccount.GetBalance, Is.EqualTo(100));
        }

        // Unit test with using mocking
        [Test]
        public void BankDeposit_Add100_ReturnTrue_Mocking()
        {
            // setting up Mock
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(el => el.Message(""));
            
            var _bankAccount = new BankAccount(loggerMock.Object);
            var result = _bankAccount.Deposit(100);
            Assert.That(result, Is.True);
            Assert.That(_bankAccount.GetBalance, Is.EqualTo(100));
        }
    }
}
