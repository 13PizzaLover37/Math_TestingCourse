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

        [Test]
        public void BankWithdraw_Withdraw100With200Balance_ReturnTrue()
        {
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(el => el.LogToDb(It.IsAny<string>())).Returns(true);
            loggerMock.Setup(el => el.LogBalanceAfterWithdraw(It.IsAny<int>())).Returns(true);

            var _bankAccount = new BankAccount(loggerMock.Object);
            _bankAccount.Deposit(200);

            var result = _bankAccount.Withdraw(100);
            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase(200,100)]
        [TestCase(300,100)]
        public void BankWithdraw_Generic_ReturnTrue(int balance, int withdraw)
        {
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(el => el.LogToDb(It.IsAny<string>())).Returns(true);
            loggerMock.Setup(el => el.LogBalanceAfterWithdraw(It.Is<int>(x => x > 0))).Returns(true);
            loggerMock.Setup(el => el.LogBalanceAfterWithdraw(It.Is<int>(x => x < 0))).Returns(false);

            var _bankAccount = new BankAccount(loggerMock.Object);
            _bankAccount.Deposit(balance);

            var result = _bankAccount.Withdraw(withdraw);
            Assert.That(result, Is.True);
        }

        [Test]
        public void BankLog_LogMockString_ReturnTrue()
        {
            var loggerMock = new Mock<ILogger>();
            var desiredOutput = "Hello";

            loggerMock.Setup(el => el.MessageWithReturnsStr(It.IsAny<string>())).Returns((string str) => str);

            Assert.That(loggerMock.Object.MessageWithReturnsStr(desiredOutput), Is.EqualTo(desiredOutput));
        }
    }
}
