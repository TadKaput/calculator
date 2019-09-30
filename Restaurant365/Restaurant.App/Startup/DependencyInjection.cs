using Microsoft.Extensions.DependencyInjection;
using Restaurant.Business.Calculator;
using Restaurant.Business.Enums;
using Restaurant.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant.App.Startup
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddManagers(this IServiceCollection services, string[] args)
        {
            var calcConfig = new CalculatorConfigModel();
            var parseConfig = new ParseConfigModel();

            //normally, this would be deserialized.
            if (args.Any(arg => arg.StartsWith("/AllowNegativeNumbers"))) calcConfig.AllowNegativeNumbers = true;
            if (args.Any(arg => arg.StartsWith("/MaximumNumber")))
            {
                var argument = args.First(arg => arg.StartsWith("/MaximumNumber"));
                var number = argument.Split(":")[1];
                calcConfig.MaximumNumber = int.Parse(number);
            }
            if (args.Any(arg => arg.StartsWith("/Operation")))
            {
                var argument = args.First(arg => arg.StartsWith("/Operation"));
                var alternate = argument.Split(":")[1];
                if (alternate.ToLower() == "+") parseConfig.Operation = OperationEnum.Add;
                if (alternate.ToLower() == "-") parseConfig.Operation = OperationEnum.Subtract;
                if (alternate.ToLower() == "*") parseConfig.Operation = OperationEnum.Multiply;
                if (alternate.ToLower() == "div") parseConfig.Operation = OperationEnum.Divide;
            }
            if (args.Any(arg => arg.StartsWith("/AlternateDelimiter")))
            {
                var argument = args.First(arg => arg.StartsWith("/AlternateDelimiter"));
                var alternate = argument.Split(":")[1];
                parseConfig.AlternateDelimiter = alternate;
            }

            services.AddSingleton<CalculatorConfigModel>(calcConfig);
            services.AddSingleton<ParseConfigModel>(parseConfig);
            services.AddSingleton<ICalculatorManager, CalculatorManager>();
            services.AddScoped<IParseManager, ParseManager>();

            return services;
        }
    }
}
