//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using NUnit.Framework;
using CalcLibrary;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new SimpleCalculator();
        }

        [TearDown]
        public void Cleanup()
        {
            calculator.AllClear();
        }

        // --- Addition --
        [TestCase(5, 3, 8)]
        [TestCase(10, -2, 8)]
        [TestCase(0, 0, 0)]

        public void TestAddition(double a, double b, double expected)
        {
            Assert.That(calculator.Addition(a, b), Is.EqualTo(expected));
        }

        // --- Subtraction ---
        [TestCase(10, 5, 5)]
        [TestCase(5, 10, -5)]
        [TestCase(0, 0, 0)]
        public void TestSubtraction(double a, double b, double expected)
        {
            Assert.That(calculator.Subtraction(a, b), Is.EqualTo(expected));
        }

        // --- Multiplication ---
        [TestCase(4, 3, 12)]
        [TestCase(0, 5, 0)]
        [TestCase(-3, 3, -9)]
        public void TestMultiplication(double a, double b, double expected)
        {
            Assert.That(calculator.Multiplication(a, b), Is.EqualTo(expected));
        }

        // --- Division ---
        [TestCase(10, 2, 5)]
        [TestCase(9, 3, 3)]
        [TestCase(-6, 2, -3)]
        public void TestDivision(double a, double b, double expected)
        {
            Assert.That(calculator.Division(a, b), Is.EqualTo(expected));
        }

        [Test]
        public void TestDivisionByZero()
        {
            try
            {
                calculator.Division(10, 0);
                Assert.Fail("Division by zero");
            }
            catch (ArgumentException ex)
            {
                Assert.That(ex.Message, Is.EqualTo("Second Parameter Can't be Zero"));
            }
        }

        // --- Void Method and Property ---
        [Test]
        public void TestAddAndClear()
        {
            double expected = 15;
            calculator.Addition(10, 5);
            Assert.That(calculator.GetResult, Is.EqualTo(expected));

            calculator.AllClear();
            Assert.That(calculator.GetResult, Is.EqualTo(0));
        }
    }
}
