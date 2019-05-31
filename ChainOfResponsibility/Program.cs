using System;
using ChainOfResponsibility.BrokerChain;
using ChainOfResponsibility.Exercise;
using ChainOfResponsibility.MethodChain;
using static System.Console;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * This implementation of chain of responsibility demonstrates the
             * method chaining approach. This approach is the most basic form in which
             * you apply various modifiers and responsibilities to the original object's
             * operations.
             */
            var ba = new BankAccount("John Doe", 1000M);
            var t = new Transaction(ba);
            
            t.AddTransaction(new SafeWithdrawTransaction(ba, 750));
            t.AddTransaction(new SafeWithdrawTransaction(ba, 500));
            t.AddTransaction(new SafeDepositTransaction(ba, 300));
            t.AddTransaction(new SafeWithdrawTransaction(ba, 250));
            t.Handle();
            
            /*
             * Below exercise demonstrates the chain of responsibility pattern
             * with a Mediator pattern approach. This can be called broker chain
             * instead of method chain since there is a broker in between the calls
             * and we avoid mutating the original object's properties.
             */

            var carGame = new CarGame();
            var car = new Car(carGame);
            WriteLine(car);
            using (new DoubleSpeedModifier(carGame, car))
            {
                WriteLine(car);
            }
            WriteLine(car);
            
            /*
             * Below is the course exercise in which we simulate a card game.
             * Goblins have default A/D points 1/1 and GoblinKing has 3/3.
             * A Goblin gets +1 defense point for every other Goblin on the board (king is a goblin)
             * All Goblins get +1 attack point when a GoblinKing is on the board.
             */

            var game = new Game();
            var c1 = new Goblin(game);
            var c2 = new Goblin(game);
            var c3 = new Goblin(game);
            var king = new GoblinKing(game);
            game.Creatures.Add(c1);
            game.Creatures.Add(c2);
            game.Creatures.Add(c3);
            game.Creatures.Add(king);
            
            WriteLine(c1);
            WriteLine(c2);
            WriteLine(c3);
            WriteLine(king);
        }
    }
}
