using NUnit.Framework;
using Restaurant.Business.Calculator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Test.Calculator
{
    public class StringCalcTest
    {
        private IStringCalcManager _stringCalcManager;

        [SetUp]
        public void Setup()
        {
            _stringCalcManager = new StringCalcManager();
        }

        [Test]
        public void DoWork()
        {
            var response = _stringCalcManager.DoWork();
            Assert.AreEqual(response, 10);

            Assert.Pass();
        }
    }
}
