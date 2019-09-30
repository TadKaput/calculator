using Restaurant.Business.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Business.Models
{
    public class CalcRequestModel
    {
        public OperationEnum Operation { get; set; }
        public List<int> Numbers { get; set; }
    }
}
