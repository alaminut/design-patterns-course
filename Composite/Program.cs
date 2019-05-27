#region Namespace Imports

using System.Collections.Generic;
using Composite.DrawingLibrary;
using Composite.Exercise;
using static System.Console;

#endregion

namespace Composite
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*
             * In this example we are using composition pattern to create various GraphicObject objects
             * which can represent a single graphic object entity like a colored square, or circle OR a group
             * of graphic objects which contains multiple GraphicObjects inside.
             */

            var drawing = new GraphicObject("My Super Drawing")
                          .AddChildren(new Rectangle(Color.Blue))
                          .AddChildren(new Square(Color.Green).AddChildren(new Rectangle(Color.Yellow)));

            var group = new GraphicObject()
                        .AddChildren(new Square(Color.Red))
                        .AddChildren(new Square(Color.Red))
                        .AddChildren(new Rectangle(Color.Yellow));

            drawing.AddChildren(group);
            WriteLine(drawing);

            /*
             * In this exercise we use composite pattern to implement an extension method
             * which operates on all List<IValueContainer> types. IValueContainer provides
             * the required composite interface for a SingleValue or ManyValues classes to
             * implement so that they can all be treated as IEnumerable<int> implementations.
             * This way, whether it is a SingleValue, or ManyValues this extension method
             * will be able to calculate the sum of all values because the implementation uses
             * composite pattern.
             */
            var manyValues = new ManyValues();
            manyValues.Add(10);
            manyValues.Add(20);
            manyValues.Add(5);

            var list = new List<IValueContainer> {new SingleValue {Value = 5}, new SingleValue {Value = 5}, manyValues};
            WriteLine(list.Sum());
        }
    }
}