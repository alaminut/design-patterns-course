using Visitor.Exercise;
using static System.Console;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var e = new AdditionExpression(new AdditionExpression(new Value(2), new Value(3)),
                                           new MultiplicationExpression(new Value(4), new Value(5)));
            var ep = new ExpressionPrinter();
            ep.Visit(e);
            
            WriteLine(ep);
        }
    }
}
