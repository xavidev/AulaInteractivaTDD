using System;
using AulaInteractivaTDD;
using NUnit.Framework;

namespace AulaInteractivaTDDTest
{
    [TestFixture]
    public class CalcProxyTests
    {

        private Calculator calculator;
        private CalcProxy calcProxy;
        private CalcProxy calcProxyWithLimits;

        [SetUp]
        public void SetUp()
        {
            calculator = new Calculator();
            calcProxy = new CalcProxy(calculator);
            calcProxyWithLimits =
                new CalcProxy(new Validator(-10, 10), calculator);
        }

        [Test]
        public void Add()
        {
           int result =
                calcProxy.BinaryOperation(calculator.Add, 2, 2);

            Assert.AreEqual(4, result);
        }

        [Test]
        public void Substract()
        {
            int result =
                calcProxy.BinaryOperation(
                    calculator.Substract, 5, 3);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void AddWithDifferentArguments()
        {
            int result =
                calcProxy.BinaryOperation(calculator.Add, 2, 5);
            Assert.AreEqual(7, result);
        }

        [Test]
        public void SubstractReturningNegative()
        {
            int result = 
                calcProxy.BinaryOperation(calculator.Substract, 3, 5);
            Assert.AreEqual(-2, result);
        }

        [Test]
        public void ArgumentsExceedLimits()
        {
            try
            {
                calcProxy.BinaryOperation(calculator.Add, 30, 50);
                Assert.Fail("This should fail as arguments exceed" +
                    "both limits");
            }
            catch (OverflowException)
            {
                //Ok, this works
            }
        }

        [Test]
        public void ArgumentsExceedLimitsInverse()
        {
            try
            {
                calcProxyWithLimits.BinaryOperation(
                                        calculator.Add, -30, -50);
                Assert.Fail("" +
                    "This should fail as arguments exceed both limits");
            }
            catch (OverflowException)
            {
                // Ok, this works
            }
        }

        [Test]
        public void ValidateResultExceedingUpperLimit()
        {
            try
            {
                calcProxyWithLimits.BinaryOperation(
                    calculator.Add, 10, 10);
                Assert.Fail(
                    "This should fail as result exceed upper limit");
            }
            catch (OverflowException)
            {
                // Ok, this works
            }
        }

        [Test]
        public void ValidateResultExceedingLowerLimit()
        {
            try
            {
                calcProxyWithLimits.BinaryOperation(
                    calculator.Add, -20, -1);
                Assert.Fail(
                    "This should fail as result exceed lower limit");
            }
            catch (OverflowException)
            {
                // Ok, this works
            }
        }
    }
}
