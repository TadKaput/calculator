using Microsoft.Extensions.DependencyInjection;
using Restaurant.Business.Calculator;
using Restaurant.App.Startup;
using System;
using Restaurant.App.Helpers;

namespace Restaurant.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Calculator...");

            //setup the DI
            IServiceCollection serviceCollection = new ServiceCollection()
                .AddManagers(args);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var parser = serviceProvider.GetService<IParseManager>();
            var calculator = serviceProvider.GetService<ICalculatorManager>();

            while (true)
            {
                Console.WriteLine("Input your formula:");
                var requestString = Console.ReadLine();
                var request = parser.ParseRequest(requestString);
                var response = calculator.ProcessCalculations(request);
                Console.WriteLine("-------------------");
                Console.WriteLine($"{request.FormatClean()} = {response}");
            }
        }

    }
}
