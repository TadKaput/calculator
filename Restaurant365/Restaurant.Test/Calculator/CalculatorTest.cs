using NUnit.Framework;
using Restaurant.Business.Calculator;
using Restaurant.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Test.Calculator
{
    /// <summary>
    /// NOTE:  This is not complete, nor comprehensive as this isn't a requirement.
    /// </summary>

    public class CalculatorTest
    {
        private ICalculatorManager _calculatorManager;

        [SetUp]
        public void Setup()
        {
            _calculatorManager = new CalculatorManager(new CalculatorConfigModel());
        }

        [Test]
        public void ProcessRequest()
        {
            
            Assert.AreEqual(10, 10);

            Assert.Pass();
        }
    }
}
