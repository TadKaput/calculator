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
    public class ParseTest
    {
        string happyPath = "1,5000";
        string test1 = "5,tytyt";
        string test2 = "1,2,3,4,5,6,7,8,9,10,11,12";
        string test3 = "1\n2,3";
        string testNegative = "-1,-2,14";
        string greaterThan1000 = "2,1001,6";
        string newDelimiter = "//;\n2;5";
        string manyDelimiters = "//[***]\n11***22***33";
        string specialDelimiters = "//[*][!!][r9r]\n11r9r22*33!!44";

        private ParseManager _parseManager;

        [SetUp]
        public void Setup()
        {
            _parseManager = new ParseManager(new ParseConfigModel());
        }

        [Test]
        public void ParseRequest()
        {
            var parsed = _parseManager.ParseRequest(happyPath);
            parsed = _parseManager.ParseRequest(test1);
            parsed = _parseManager.ParseRequest(test2);
            parsed = _parseManager.ParseRequest(test3);
            parsed = _parseManager.ParseRequest(testNegative);
            parsed = _parseManager.ParseRequest(greaterThan1000);
            parsed = _parseManager.ParseRequest(newDelimiter);
            parsed = _parseManager.ParseRequest(manyDelimiters);
            parsed = _parseManager.ParseRequest(specialDelimiters);

            Assert.Pass();
        }

        [Test]
        public void ParseDelimiters()
        {
            var response = _parseManager.ParseDelimiters(happyPath);

            response = _parseManager.ParseDelimiters(test1);

            response = _parseManager.ParseDelimiters(test2);

            response = _parseManager.ParseDelimiters("//[*][!!][r9r]\n11r9r22*33!!44");
        }
    }
}
