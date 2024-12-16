using Math;

namespace CalculatorMSTest
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]

        public void SumNumbers_InputTwoNumbers_GetCorrectAddition()
        {
            // Arrange
            var calculator = new Math.Calculator();
            int firstInt = 0;
            int secondInt = 0;
            // Act
            var result = calculator.Sum(new int[] { firstInt, secondInt });
            // Assert

            Assert.AreEqual(0, result);
        }
    }
}