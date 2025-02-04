using ModulesForTesting.Modules.Calculator;
using System.Collections.Generic;
using Xunit;

namespace CalculatorXUnitTest
{
    public class CalculatorXUnitTests
    {
        Calculator calculator = new Calculator();

        [Fact]
        public void SumNumbers_InputTwoNumbers_GetCorrectAddition()
        {
            // Arrange
            int firstInt = 0;
            int secondInt = 0;

            // Act
            var result = calculator.Sum(new int[] { firstInt, secondInt });

            // Assert
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData(10, true)]
        [InlineData(11, false)]
        public void IsOdd_InputOddNumber_GetCorrectResponse(int value, bool result)
        {
            // Act
            var calculationResult = calculator.IsOddNumber(value);

            // Assert
            Assert.Equal(result, calculationResult);
        }

        [Theory]
        [InlineData(10, true)]
        [InlineData(11, false)]
        public void IsOdd_InputNumber_GetCorrectResponse(int value, bool expectedResult) => Assert.Equal(expectedResult, calculator.IsOddNumber(value));

        [Fact]
        public void RangeOddNumbers_GetCorrectAnswer()
        {
            var test1 = new List<int>() { 5, 7, 9 };
            var response_test1 = calculator.GetRangeOfOddNumbers(5, 10).ToList();

            var test2 = new List<int>() { 11, 13, 15, 17, 19 };
            var response_test2 = calculator.GetRangeOfOddNumbers(10, 20).ToList();
            Assert.Equal(test1, response_test1);
            Assert.Equal(test2, response_test2);
            Assert.NotNull(response_test1);
            Assert.NotNull(response_test2);
            Assert.Equal(3, response_test1.Count);
            Assert.True(response_test1.SequenceEqual(response_test1.OrderBy(x => x)));                
            Assert.True(response_test1.Count == response_test1.Distinct().Count());
        }
    }
}
