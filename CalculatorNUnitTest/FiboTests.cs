using Calculator;
using NUnit.Framework;

namespace Math
{
    [TestFixture]
    public class FiboTests
    {
        Fibo fibo;

        [SetUp]
        public void Setup() => fibo = new Fibo();

        [Test]
        public void GetFiboSeries_Input_1()
        {
            var correctAnswer = new List<int>() { 0 };
            var results = fibo.GetFiboSeries(1);

            Assert.That(results, Is.Not.Empty);
            Assert.That(results, Is.Ordered);
            Assert.That(results, Is.EquivalentTo(correctAnswer));
        }

        [Test]
        public void GetFiboSeries_Input_6()
        {
            var correctAnswer = new List<int>() { 0, 1, 1, 2, 3, 5 };

            var results = fibo.GetFiboSeries(6);

            // helps us to run all of the test cases, even if an error will occure
            Assert.Multiple(() =>
            {
                // I know, that this way to check probably isn't correct, but I wanted to try it
                Assert.That(results.Contains(3), Is.True);

                Assert.That(results, Does.Contain(3));
                Assert.That(results.Count, Is.EqualTo(6));
                
                // 3 ways to write the same logic
                Assert.That(results, Is.Not.Contain(4));
                Assert.That(results, Has.No.Member(4));
                Assert.That(results, Does.Not.Contain(4));
                
                Assert.That(results, Is.EquivalentTo(correctAnswer));
            });
        }
    }
}
