using ModulesForTesting.Modules.GradingCalculatorModule;
using NUnit.Framework;

namespace Math
{
    [TestFixture]
    public class GradingCalculatorNUnitTests
    {
        private GradingCalculator _gradingCalculator;

        [SetUp]
        public void Setup() => _gradingCalculator = new GradingCalculator();

        [Test]
        [TestCase(95, 90, ExpectedResult = "A")]
        [TestCase(85, 90, ExpectedResult = "B")]
        [TestCase(65, 90, ExpectedResult = "C")]
        [TestCase(95, 65, ExpectedResult = "B")]
        [TestCase(95, 55, ExpectedResult = "F")]
        [TestCase(65, 55, ExpectedResult = "F")]
        [TestCase(50, 90, ExpectedResult = "F")]
        public string GetGrade_ReceiveCorrectAnswers(int score, int attendancePercentage)
        {
            return _gradingCalculator.GetGrade(score, attendancePercentage);
        }
    }
}
