using Restaurant.Business.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Business.Models
{
    public class CalculatorConfigModel
    {
        public bool AllowNegativeNumbers { get; set; } = false;
        public int MaximumNumber { get; set; } = 1000;
    }
}
