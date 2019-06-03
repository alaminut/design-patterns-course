using TemplateMethod.Exercise;
using static System.Console;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var c1 = new Creature(1, 2);
            var c2 = new Creature(1, 1);
            var game = new TemporaryCardDamageGame(new[] {c1, c2}); 
            var winner = -1;
            var turn = 1;
            var maxTurns = 10;
            while(winner < 0 && turn < maxTurns)
            {
                WriteLine($"Turn {turn}");
                winner = game.Combat(0, 1);
                ++turn;
            }

            WriteLine(winner >= 0 ? $"Winner is creature {winner + 1}" : "Draw!");
        }
    }
}
