using ModulesForTesting.Interfaces;
using ModulesForTesting.Modules.BankModule;
using ModulesForTesting.Modules.CustomerModule;
using Moq;
using Xunit;

namespace CalculatorXUnitTest
{
    public class BankAccountXUnitTests
    {
        // Integrational test, NOT unit
        // because method Deposit has an external object(logger)
        [Fact]
        public void BankDeposit_Add100_ReturnTrue_Integrational_Test()
        {
            var _bankAccount = new BankAccount(new Logger());
            var result = _bankAccount.Deposit(100);

            Assert.True(result);
            Assert.True(_bankAccount.GetBalance() == 100);
        }

        // Unit test using mocking
        [Fact]
        public void BankDeposit_Add100_ReturnTrue_Mocking()
        {
            // setting up Mock
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(el => el.Message(""));

            var _bankAccount = new BankAccount(loggerMock.Object);
            var result = _bankAccount.Deposit(100);
            
            Assert.True(result);
            Assert.True(_bankAccount.GetBalance() == 100);
        }

        [Fact]
        public void BankWithdraw_Withdraw100With200Balance_ReturnTrue()
        {
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(el => el.LogToDb(It.IsAny<string>())).Returns(true);
            loggerMock.Setup(el => el.LogBalanceAfterWithdraw(It.IsAny<int>())).Returns(true);

            var _bankAccount = new BankAccount(loggerMock.Object);
            _bankAccount.Deposit(200);

            var result = _bankAccount.Withdraw(100);
            Assert.True(result);
        }

        [Theory]
        [InlineData(200, 100)]
        [InlineData(300, 100)]
        public void BankWithdraw_Generic_ReturnTrue(int balance, int withdraw)
        {
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(el => el.LogToDb(It.IsAny<string>())).Returns(true);
            loggerMock.Setup(el => el.LogBalanceAfterWithdraw(It.Is<int>(x => x > 0))).Returns(true);
            loggerMock.Setup(el => el.LogBalanceAfterWithdraw(It.Is<int>(x => x < 0))).Returns(false);

            var _bankAccount = new BankAccount(loggerMock.Object);
            _bankAccount.Deposit(balance);

            var result = _bankAccount.Withdraw(withdraw);
            Assert.True(result);
        }

        [Fact]
        public void BankLog_LogMockString_ReturnTrue()
        {
            var loggerMock = new Mock<ILogger>();
            var desiredOutput = "Hello";

            loggerMock.Setup(el => el.MessageWithReturnsStr(It.IsAny<string>())).Returns((string str) => str);

            Assert.Equal(loggerMock.Object.MessageWithReturnsStr(desiredOutput), desiredOutput);
        }

        [Fact]
        public void BankLog_LogMockStringOutputStr_ReturnTrue()
        {
            var loggerMock = new Mock<ILogger>();

            // by writing text here and setting the variable as an out, we tell the setup, what text in out should be
            var desiredOutput = "Hello";

            loggerMock.Setup(el => el.MessageWithOutString(It.IsAny<string>(), out desiredOutput)).Returns(true);

            string result = "";
            Assert.True(loggerMock.Object.MessageWithOutString("Steve", out result));
            Assert.Equal(desiredOutput, result);
        }

        [Fact]
        public void BankLog_LogMockRefCheck_ReturnTrue()
        {
            var loggerMock = new Mock<ILogger>();
            Customer customer = new();

            // ! Important !
            // if we send !customer object to Assert, the Assert will return false
            loggerMock.Setup(el => el.MessageWithRefObj(ref customer)).Returns(true);

            Assert.True(loggerMock.Object.MessageWithRefObj(ref customer));
        }

        [Fact]
        public void BankLog_SetAndGetServerCodeAndServerType_MockTest()
        {
            var mock = new Mock<ILogger>();

            mock.Setup(el => el.ServerCode).Returns(404);
            mock.Setup(el => el.LogType).Returns("Warning");

            Assert.Equal(404, mock.Object.ServerCode);
            Assert.Equal("Warning", mock.Object.LogType);

            // Warning!
            // If we want to set up a mock parameter like
            // mock.LogType = "warning" -> we will fall
            // for this type of setting, we have to use mock.SetupAllPrroperties(); in the beginning of a test method
        }

        [Fact]
        public void BankLog_SetAndGetServerCodeAndServerType_WithSetupAllProperties_MockTest()
        {
            var mock = new Mock<ILogger>();
            mock.SetupAllProperties();

            mock.Object.ServerCode = 404;
            mock.Object.LogType = "Warning";

            Assert.Equal(404, mock.Object.ServerCode);
            Assert.Equal("Warning", mock.Object.LogType);

            // Warning!
            // If we want to set up a mock parameter like
            // mock.LogType = "warning" -> we will fall
            // for this type of setting, we have to use mock.SetupAllPrroperties(); in the beginning of a test method
        }

        [Fact]
        public void BankLog_Callbacks_MockTest()
        {
            var mock = new Mock<ILogger>();

            // callbacks
            var greeting = "Hello, ";

            mock.Setup(el => el.LogToDb(It.IsAny<string>()))
                .Returns(true)
                .Callback((string input) => greeting += input);

            mock.Object.LogToDb("John");
            Assert.Equal("Hello, John", greeting);

            // counter callback
            var counter = 0;

            mock.Setup(el => el.LogToDb(It.IsAny<string>()))
                .Returns(true)
                .Callback(() => counter++);

            mock.Object.LogToDb("John");
            mock.Object.LogToDb("Dave");
            mock.Object.LogToDb("Steve");

            Assert.Equal(3, counter);

            // Warning
            // we can write callback even before .returns
            mock.Setup(el => el.LogToDb(It.IsAny<string>()))
               .Callback(() => counter++)
               .Returns(true);
        }

        [Fact]
        public void BankLog_VerifyUsingMethods()
        {
            var mock = new Mock<ILogger>();
            BankAccount bankAccount = new BankAccount(mock.Object);

            bankAccount.Deposit(100);
            Assert.Equal(100, bankAccount.GetBalance());

            // verification
            mock.Verify(el => el.Message(It.IsAny<string>()), Times.Exactly(2));

            // if we want to check if the method got the specific parametr at least once
            mock.Verify(el => el.Message("Deposit invoked"), Times.AtLeastOnce);

            // as we work with properties, we can use .VerifySet/.VerifyGet
            // to check how many times the program set/get a special value
            mock.VerifySet(el => el.ServerCode = 200, Times.Once);
            mock.VerifyGet(el => el.ServerCode, Times.Once);
        }
    }
}
