using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Business.Calculator
{
    public interface IStringCalcManager
    {
        int DoWork();
    }

    public class StringCalcManager : IStringCalcManager
    {
        public StringCalcManager()
        {

        }

        public int DoWork()
        {
            return 10;
        }
    }
}
