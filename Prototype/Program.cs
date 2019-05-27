using System;
using static System.Console;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * In this implementation example we simulate a scenario in which we have an
             * AnnualReport object that is expensive to generate. And in order to change it's
             * sort order in two different views instead of re-creating the object again we're
             * utilizing Prototype pattern to create a clone of it (deep clone) to change it's sort order.
             *
             * copy constructor and interface implementation methods are rather trivial to implement so they are
             * omitted in this example. Bu normally, with an object this simple it might be better to utilize one of
             * those methods since this extension method comes with other caveats.
             */

            var report = new AnnualReport(1000.0M, 125.26M, 4200M, 10M);
            WriteLine("\nAscending Ordered Report");
            WriteLine(string.Join(Environment.NewLine, report.Expenses));

            var reportDescending = report.DeepCopy();
            reportDescending.Order = SortOrder.Descending;
            
            WriteLine("\nDescending Ordered Report");
            WriteLine(string.Join(Environment.NewLine, reportDescending.Expenses));
        }
    }
}