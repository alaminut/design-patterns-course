using System;
using static System.Console;

namespace NullObject
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = new NullLog();
            var ba = new Account(log);
            ba.SomeOperation();
        }
    }
}
