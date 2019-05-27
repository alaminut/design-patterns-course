#region Namespace Imports

using Facade.Exercise;
using static System.Console;

#endregion

namespace Facade
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*
             * In this example MagicSquareGenerator is a Facade on the complex
             * operation of generating a square matrix of magic number.
             */
            var msg = new MagicSquareGenerator();
            var matrix = msg.Generate(2);

            WriteLine("Magic square generated.");
        }
    }
}