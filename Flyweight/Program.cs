#region Namespace Imports

using Flyweight.Exercise;
using static System.Console;

#endregion

namespace Flyweight
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var s = new Sentence("the show must go on!");
            s.CapitalizeWord(2);
            WriteLine(s);
            
            var fs = new FlyweightSentence("the show must go on!");
            fs[1].Capitalize = true;
            WriteLine(fs);
        }
    }
}