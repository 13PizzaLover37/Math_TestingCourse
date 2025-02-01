using ModulesForTesting.Interfaces;
using ModulesForTesting.Modules.BankModule;
using ModulesForTesting.Modules.CustomerModule;
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

        [Test]
        public void BankLog_LogMockStringOutputStr_ReturnTrue()
        {
            var loggerMock = new Mock<ILogger>();

            // by writing text here and setting the variable as an out, we tell the setup, what text in out should be
            var desiredOutput = "Hello";

            loggerMock.Setup(el => el.MessageWithOutString(It.IsAny<string>(), out desiredOutput)).Returns(true);

            string result = "";
            Assert.That(loggerMock.Object.MessageWithOutString("Steve", out result), Is.True);
            Assert.That(result, Is.EqualTo(desiredOutput));
        }

        [Test]
        public void BankLog_LogMockRefCheck_ReturnTrue()
        {
            var loggerMock = new Mock<ILogger>();
            Customer customer = new();

            // ! Important !
            // if we send !customer object to Assert, the Assert will return false
            loggerMock.Setup(el => el.MessageWithRefObj(ref customer)).Returns(true);

            Assert.That(loggerMock.Object.MessageWithRefObj(ref customer), Is.True);
        }

        [Test]
        public void BankLog_SetAndGetServerCodeAndServerType_MockTest()
        {
            var mock = new Mock<ILogger>();

            mock.Setup(el => el.ServerCode).Returns(404);
            mock.Setup(el => el.LogType).Returns("Warning");
            
            Assert.That(mock.Object.ServerCode, Is.EqualTo(404));
            Assert.That(mock.Object.LogType, Is.EqualTo("Warning"));

            // Warning!
            // If we want to set up a mock parameter like
            // mock.LogType = "warning" -> we will fall
            // for this type of setting, we have to use mock.SetupAllPrroperties(); in the beginning of a test method
        }

        [Test]
        public void BankLog_SetAndGetServerCodeAndServerType_WithSetupAllProperties_MockTest()
        {
            var mock = new Mock<ILogger>();
            mock.SetupAllProperties();

            mock.Object.ServerCode = 404;
            mock.Object.LogType = "Warning";

            Assert.That(mock.Object.ServerCode, Is.EqualTo(404));
            Assert.That(mock.Object.LogType, Is.EqualTo("Warning"));

            // Warning!
            // If we want to set up a mock parameter like
            // mock.LogType = "warning" -> we will fall
            // for this type of setting, we have to use mock.SetupAllPrroperties(); in the beginning of a test method
        }

        [Test]
        public void BankLog_Callbacks_MockTest()
        {
            var mock = new Mock<ILogger>();

            // callbacks
            var greeting = "Hello, ";

            mock.Setup(el => el.LogToDb(It.IsAny<string>()))
                .Returns(true)
                .Callback((string input) => greeting += input);

            mock.Object.LogToDb("John");

            Assert.That(greeting, Is.EqualTo("Hello, John"));

            // counter callback
            var counter = 0;

            mock.Setup(el => el.LogToDb(It.IsAny<string>()))
                .Returns(true)
                .Callback(() => counter++);

            mock.Object.LogToDb("John");
            mock.Object.LogToDb("Dave");
            mock.Object.LogToDb("Steve");

            Assert.That(counter, Is.EqualTo(3));

            // Warning
            // we can write callback even before .returns
            mock.Setup(el => el.LogToDb(It.IsAny<string>()))
               .Callback(() => counter++)
               .Returns(true);
        }
    }
}
