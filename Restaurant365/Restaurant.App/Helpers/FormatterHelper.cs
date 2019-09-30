using Restaurant.Business.Enums;
using Restaurant.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.App.Helpers
{
    public static class FormatterHelper
    {
        public static string FormatClean(this CalcRequestModel request)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(request.Numbers[0].ToString());
            for(var i = 1; i< request.Numbers.Count; i++)
            {
                sb.Append(request.Operation.GetSymbolString());
                sb.Append(request.Numbers[i]);
            }
            return sb.ToString();
        }

        public static string GetSymbolString(this OperationEnum symbolEnum)
        {
            switch (symbolEnum)
            {
                case OperationEnum.Add:
                    return "+";
                case OperationEnum.Divide:
                    return "/";
                case OperationEnum.Multiply:
                    return "*";
                case OperationEnum.Subtract:
                    return "-";
                default:
                    throw new NotImplementedException("Your symbol is not implemented.");
            }
        }
    }
}
