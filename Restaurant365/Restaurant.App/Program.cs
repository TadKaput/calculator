using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Restaurant.Business.Calculator;
using System;

namespace Restaurant.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Calculator...");

            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IStringCalcManager, StringCalcManager>()
                .BuildServiceProvider();

            //do the actual work here
            var stringCalc = serviceProvider.GetService<IStringCalcManager>();

            Console.WriteLine("Application has exited normally.");
        }
    }
}
