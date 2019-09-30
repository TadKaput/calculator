using NUnit.Framework;
using Restaurant.Business.Calculator;
using Restaurant.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Test
{
    public class Requirements
    {
        private CalculatorManager _calculatorManager;
        private ParseManager _parseManager;

        [SetUp]
        public void Setup()
        {
            var calcConfig = new CalculatorConfigModel();
            var parseConfig = new ParseConfigModel();
            _calculatorManager = new CalculatorManager(calcConfig);
            _parseManager = new ParseManager(parseConfig);
        }

        /// <summary>
        /// Support a maximum of 2 numbers using a comma delimiter
        /// examples: 20 will return 20; 1,5000 will return 5001
        /// invalid/missing numbers should be converted to 0 e.g. "" will return 0; 5,tytyt will return 5
        /// </summary>
        [Test]
        public void Requirement1()
        {
            var calcManager = new CalculatorManager(new CalculatorConfigModel()
            {
                MaximumNumber = int.MaxValue
            });
            var request = _parseManager.ParseRequest("1,5000");
            var answer = calcManager.ProcessCalculations(request);
            Assert.AreEqual(answer, 5001);

            var request1 = _parseManager.ParseRequest("5,tytyt");
            var answer1 = calcManager.ProcessCalculations(request1);
            Assert.AreEqual(answer1, 5);
        }

        /// <summary>
        /// Support an unlimited number of numbers e.g. 1,2,3,4,5,6,7,8,9,10,11,12 will return 78
        /// </summary>
        [Test]
        public void Requirement2()
        {
            var request = _parseManager.ParseRequest("1,2,3,4,5,6,7,8,9,10,11,12");
            var answer = _calculatorManager.ProcessCalculations(request);
            Assert.AreEqual(answer, 78);
        }

        /// <summary>
        /// Support a newline character as an alternative delimiter e.g. 1\n2,3 will return 6
        /// </summary>
        [Test]
        public void Requirement3()
        {
            var request = _parseManager.ParseRequest("1\n2,3");
            var answer = _calculatorManager.ProcessCalculations(request);
            Assert.AreEqual(answer, 6);
        }

        /// <summary>
        /// Deny negative numbers. An exception should be thrown that includes all of the negative numbers provided
        /// </summary>
        [Test]
        public void Requirement4()
        {
            var request = _parseManager.ParseRequest("1,-3");
            var exception = Assert.Catch(()=> _calculatorManager.ProcessCalculations(request));
        }

        /// <summary>
        /// Ignore any number greater than 1000 e.g. 2,1001,6 will return 8
        /// </summary>
        [Test]
        public void Requirement5()
        {
            var request = _parseManager.ParseRequest("2,1001,6");
            var answer = _calculatorManager.ProcessCalculations(request);
            Assert.AreEqual(answer, 8);
        }

        /// <summary>
        /// Support 1 custom single character length delimiter
        /// use the format: //{delimiter}\n{numbers} e.g. //;\n2;5 will return 7
        /// all previous formats should also be supported
        /// </summary>
        [Test]
        public void Requirement6()
        {
            var request = _parseManager.ParseRequest("//;\n2;5");
            var answer = _calculatorManager.ProcessCalculations(request);
            Assert.AreEqual(answer, 7);
        }

        /// <summary>
        /// Support 1 custom delimiter of any length
        /// use the format: //[{delimiter}]\n{numbers} e.g. //[***]\n11***22***33 will return 66
        /// all previous formats should also be supported
        /// </summary>
        [Test]
        public void Requirement7()
        {
            var request = _parseManager.ParseRequest("//[***]\n11***22***33");
            var answer = _calculatorManager.ProcessCalculations(request);
            Assert.AreEqual(answer, 66);
        }

        /// <summary>
        /// Support multiple delimiters of any length
        /// use the format: //[{delimiter1}][{delimiter2}]...\n{numbers} e.g. //[*][!!][r9r]\n11r9r22*33!!44 will return 110
        /// all previous formats should also be supported
        /// </summary>
        [Test]
        public void Requirement8()
        {
            var request = _parseManager.ParseRequest("//[*][!!][r9r]\n11r9r22*33!!44");
            var answer = _calculatorManager.ProcessCalculations(request);
            Assert.AreEqual(answer, 110);
        }
    }
}
