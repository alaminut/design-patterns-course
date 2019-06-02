using State.Exercise;
using static System.Console;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            var cl = new CombinationLock(new[] {1, 2, 3, 4});
            WriteLine("Enter code to unlock");
            while (cl.Status != CombinationLock.Open)
            {
                var digit = int.Parse(ReadKey().KeyChar.ToString());
                cl.EnterDigit(digit);
                CursorLeft = 0;
                Write(cl.Status);
            }
        }
    }
}
