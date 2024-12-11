using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Math
{
    [TestFixture]
    public class CalculatorNUnitTests
    {
        Calculator calculator = new Calculator();

        [Test]
        public void SumNumbers_InputTwoNumbers_GetCorrectAddition()
        {
            // Arrange
            int firstInt = 0;
            int secondInt = 0;
            // Act
            var result = calculator.Sum(new int[] { firstInt, secondInt });
            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        [TestCase(10, true)]
        [TestCase(11, false)]
        public void IsOdd_InputOddNumber_GetCorrectResponse(int value, bool result)
        {
            // Act
            var calculationResult = calculator.IsOddNumber(value);

            // Assert
            Assert.That(calculationResult, Is.EqualTo(result));
        }

        [Test]
        [TestCase(10, ExpectedResult = true)]
        [TestCase(11, ExpectedResult = false)]
        public bool IsOdd_InputNumber_GetCorrectResponse(int value) => calculator.IsOddNumber(value);

        [Test]
        public void RangeOddNumbers_GetCorrectAnswer()
        {
            var test1 = new List<int>() { 5, 7, 9 };
            var response_test1 = calculator.GetRangeOfOddNumbers(5, 10).ToList();

            var test2 = new List<int>() { 11, 13, 15, 17, 19 };
            var response_test2 = calculator.GetRangeOfOddNumbers(10, 20).ToList();
            ClassicAssert.AreEqual(response_test1, test1);
            ClassicAssert.AreEqual(response_test2, test2);
            Assert.That(response_test1, Is.Not.Empty);
            Assert.That(response_test2, Is.Not.Empty);
            Assert.That(response_test1.Count, Is.EqualTo(3));
            Assert.That(response_test1, Is.Ordered);
            //Assert.That(response_test1, Is.Ordered.Descending);
            Assert.That(response_test1, Is.Unique);
            //Assert.That(response_test1, Is.EquivalentTo(test1));
            //Assert.That(response_test2, Is.EquivalentTo(test2));
        }

        [Test]
        public async Task TestOfTest()
        {
            var result = await calculator.AsyncMath();
            Assert.That(result, Is.EqualTo(4));
        }
    }
}
