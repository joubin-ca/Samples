using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class LoggerService : ILoggerService
    {
        public void Debug(string msg)
        {
            Console.WriteLine(msg);
        }
    }

    public class ServiceAImplementation : IServiceA
    {
        private readonly IServiceB _serviceB;

        public ServiceAImplementation(IServiceB serviceB)
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

    public class ServiceBImplementation : IServiceB
    {
        private readonly ILoggerService _logger;

        public ServiceBImplementation(ILoggerService loggerFactory)
        {
            _logger = loggerFactory;
        }

        public void Print(int number)
        {
            _logger.Debug($"ServiceB: {number}");
        }
    }
}
