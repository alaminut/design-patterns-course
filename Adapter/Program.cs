#region Namespace Imports

using static System.Console;

#endregion

namespace Adapter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*
             * In this adapter example we attempt to create a SquareToRectangle adapter class
             * which basically converts a Square to rectangle and then we calculate the area
             * of said rectangle with an extension helper method.
             */

            var square = new Square {Side = 4};
            var rectangle = new SquareToRectangleAdapter(square);

            WriteLine($"Area of square with {square.Side} sides is {rectangle.Area()}");
        }
    }
}