using System;
using Interpreter.Exercise;
using static System.Console;

namespace Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "1+23+c";
            var p = new ExpressionProcessor();
            p.Variables.Add('c', 6);
            WriteLine(p.Calculate(input));
        }
    }
}
