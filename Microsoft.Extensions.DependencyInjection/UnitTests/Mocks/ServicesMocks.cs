using Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace UnitTests.Mocks
{
    public class LoggerMockService : ILoggerService
    {
        public void Debug(string msg)
        {
            System.Diagnostics.Debug.WriteLine($"TEST: {msg}");
        }
    }

    public class ServiceAMock : IServiceA
    {
        private readonly IServiceB _serviceB;

        public ServiceAMock(IServiceB serviceB)
        {
            _serviceB = serviceB;
        }

        public void PrintCount(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _serviceB.Print(i);
            }
        }
    }

    public class ServiceBMock : IServiceB
    {
        private readonly ILoggerService _logger;

        public ServiceBMock(ILoggerService loggerFactory)
        {
            _logger = loggerFactory;
        }

        public void Print(int num)
        {
            _logger.Debug($"ServiceB Test: {num}");
        }
    }
}
