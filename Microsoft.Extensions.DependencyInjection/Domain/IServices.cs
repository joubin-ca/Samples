using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IServiceB
    {
        void Print(int number);
    }

    public interface IServiceA
    {
        void PrintCount(int i);
    }

    public interface ILoggerService
    {
        void Debug(string msg);
    }
}
