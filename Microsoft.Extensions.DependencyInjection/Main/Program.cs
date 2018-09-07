using Domain;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Main
{
    class Program
    {
        private static IServiceProvider serviceProvider;

        static void Main(string[] args)
        {
            serviceProvider = ConfigureServices();

            var serviceA = serviceProvider.GetService<IServiceA>();
            serviceA.PrintCount(5);

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        static private IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection
                .AddSingleton<IServiceA, ServiceAImplementation>()
                .AddSingleton<IServiceB, ServiceBImplementation>()
                .AddSingleton<ILoggerService, LoggerService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
