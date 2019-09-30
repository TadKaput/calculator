using Restaurant.Business.Enums;
using Restaurant.Business.Exceptions;
using Restaurant.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant.Business.Calculator
{
    public interface ICalculatorManager
    {
        int ProcessCalculations(CalcRequestModel request);
    }

    public class CalculatorManager : ICalculatorManager
    {
        private CalculatorConfigModel _config;

        public CalculatorManager(CalculatorConfigModel config)
        {
            _config = config;
        }

        public int ProcessCalculations(CalcRequestModel request)
        {
            request = Validate(request);
            switch (request.Operation)
            {
                case OperationEnum.Add:
                    return request.Numbers.Sum();
                case OperationEnum.Subtract:
                    var sum = request.Numbers[0];
                    for(var i = 1; i<request.Numbers.Count; i++)
                    {
                        sum -= request.Numbers[i];
                    }
                    return sum;
                case OperationEnum.Multiply:
                    var factor = request.Numbers[0];
                    for (var i = 1; i < request.Numbers.Count; i++)
                    {
                        factor = factor * request.Numbers[i];
                    }
                    return factor;
                case OperationEnum.Divide:
                    var numerator = request.Numbers[0];
                    for (var i = 1; i < request.Numbers.Count; i++)
                    {
                        numerator = numerator / request.Numbers[i];
                    }
                    return numerator;
                default:
                    throw new NotImplementedException("Unrecognized mathematical operator");
            }
        }

        private CalcRequestModel Validate(CalcRequestModel request)
        {
            if (!_config.AllowNegativeNumbers && request.Numbers.Any(num => num < 0)) throw new NegativeNumberException();
            request.Numbers = request.Numbers.Where(num => num <= _config.MaximumNumber).ToList();

            return request;
        }

    }
}
