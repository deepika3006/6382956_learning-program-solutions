using NUnit.Framework;
using CalcLibrary;

namespace CalcLibraryTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator calc;

        [SetUp]
        public void Init()
        {
            calc = new SimpleCalculator();
        }

        [TearDown]
        public void Cleanup()
        {
            calc.AllClear();
        }

        // ✅ Addition Tests
        [Test]
        [TestCase(10, 5, 15)]
        [TestCase(-2, -3, -5)]
        [TestCase(0, 0, 0)]
        [TestCase(100.5, 200.25, 300.75)]
        public void TestAddition(double a, double b, double expected)
        {
            double result = calc.Addition(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        // ➖ Subtraction Tests
        [Test]
        [TestCase(10, 5, 5)]
        [TestCase(-2, -3, 1)]
        [TestCase(5, 10, -5)]
        public void TestSubtraction(double a, double b, double expected)
        {
            double result = calc.Subtraction(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        // ✖️ Multiplication Tests
        [Test]
        [TestCase(2, 3, 6)]
        [TestCase(-2, 3, -6)]
        [TestCase(0, 10, 0)]
        public void TestMultiplication(double a, double b, double expected)
        {
            double result = calc.Multiplication(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        // ➗ Division Tests
        [Test]
        [TestCase(10, 2, 5)]
        [TestCase(-10, 2, -5)]
        [TestCase(9, 3, 3)]
        public void TestDivision(double a, double b, double expected)
        {
            double result = calc.Division(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        // ❌ Division by Zero Test
        [Test]
        public void Division_ByZero_ThrowsException()
        {
            Assert.Throws<System.ArgumentException>(() => calc.Division(10, 0));
        }
    }
}
