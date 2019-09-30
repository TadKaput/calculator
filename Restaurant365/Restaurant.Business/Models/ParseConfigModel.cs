using Restaurant.Business.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Business.Models
{
    public class ParseConfigModel
    {
        public string AlternateDelimiter { get; set; } = string.Empty;
        public OperationEnum Operation { get; set; } = OperationEnum.Add;
    }
}
