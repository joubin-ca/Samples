using Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using UnitTests.Mocks;
using Xunit;

namespace UnitTests
{
    public class ServiceATests
    {
        private ServiceProvider _serviceProvider;

        public ServiceATests()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection
                .AddSingleton<IServiceA, ServiceAMock>()
                .AddSingleton<IServiceB, ServiceBMock>()
                .AddSingleton<ILoggerService, LoggerMockService>();

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        [Fact]
        public void Test1()
        {
            var serviceA = _serviceProvider.GetRequiredService<IServiceA>();
            serviceA.PrintCount(10);
        }
    }
}
