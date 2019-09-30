using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Test
{
    public class StretchGoals
    {
        /// <summary>
        /// Display the formula used to calculate the result e.g. 2,4,rrrr,1001,6 will return 2+4+0+0+6 = 12
        /// </summary>
        [Test]
        public void Requirement1()
        {
            Assert.Pass();
        }

        /// <summary>
        /// Allow the application to process entered entries until Ctrl+C is used
        /// </summary>
        [Test]
        public void Requirement2()
        {
            Assert.Pass();
        }

        /// <summary>
        /// Allow the acceptance of arguments to define...
        /// alternate delimiter in step #3
        /// toggle whether to deny negative numbers in step #4
        /// upper bound in step #5
        /// </summary>
        [Test]
        public void Requirement3()
        {
            //NOTE: "Alternate" delimiter is assumed to NOT mean that the delimiter is exclusive with "\n"
            Assert.Pass();
        }

        /// <summary>
        /// Use DI
        /// </summary>
        [Test]
        public void Requirement4()
        {
            Assert.Pass();
        }

        /// <summary>
        /// Support subtraction, multiplication, and division operations
        /// </summary>
        [Test]
        public void Requirement5()
        {
            Assert.Pass();
        }
    }
}
