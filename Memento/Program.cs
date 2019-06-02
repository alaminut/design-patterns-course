using System;
using Memento.Exercise;
using Memento.Simple;
using Memento.UndoRedo;
using static System.Console;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * This is a trivial example of implementing memento pattern.
             * In this example our bank account methods return a snapshot of it's balance
             * after the operation so that we can save those tokens and restore our account
             * to any state later.
             */
            var ba = new SimpleBankAccount(100);
            var s1 = ba.Deposit(50); // 150
            var s2 = ba.Deposit(100); // 250
            
            WriteLine(ba);
            
            ba.Restore(s1);
            WriteLine(ba);
            
            ba.Restore(s2);
            WriteLine(ba);
            
            /*
             * This example illustrates a more advanced example of memento pattern
             * as a form of undo and redo implementation.
             */
            var b = new BankAccount(100);
            b.Deposit(50);
            var as1 = b.Deposit(25);
            WriteLine(b);

            b.Undo();
            WriteLine($"Undo 1 {b}");
            b.Undo();
            WriteLine($"Undo 2 {b}");
            b.Redo();
            WriteLine($"Redo {b}");
            b.Restore(as1);
            WriteLine($"Restore {b}");

            var tm = new TokenMachine();
            var testToken = new Token(1);
            var h1 = tm.AddToken(testToken); // 1
            var h2 = tm.AddToken(new Token(3)); // 1, 3
            var h3 = tm.AddToken(new Token(5)); // 1,3,5
            
            WriteLine(tm);
            testToken.Value = 10;
            WriteLine(tm); // 10,3,5
            tm.Revert(h2);
            WriteLine(tm); // 1, 3
        }
    }
}
