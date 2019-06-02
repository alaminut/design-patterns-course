using Observer.EventBased;
using Observer.Exercise;
using Observer.Rx;
using static System.Console;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * In this example we are using .net event system to implement
             * observer pattern. Our bank account raises an event whenever it's balance
             * has changed so that external subscribers can react accordingly.
             * This method is very simple and has it's drawbacks - since this environment
             * is .net core, we are not able to use WeakEventManager which means subscribers
             * can cause memory leaks if they does not unsubscribe properly.
             */
            var ba = new BankAccount(100);
            ba.BalanceChanged += AccountBalanceUpdated;
            
            ba.Deposit(50);
            ba.Deposit(150);
            ba.BalanceChanged -= AccountBalanceUpdated;
            ba.Deposit(10);
            WriteLine(ba.Balance);
            
            /*
             * This example uses Reactive Extensions (Rx) library of .Net
             * and implements IObservable<T> and IObserver<T> to demonstrate
             * Observer pattern without events.
             */
            var shooter = new ShooterGame();
            var enemy1 = new Enemy("Enemy 1");
            var enemy2 = new Enemy("Enemy 2");
            shooter.AddEnemy(enemy1);
            shooter.AddEnemy(enemy2);
            
            enemy1.Fire();
            enemy2.Fire();
            shooter.RemoveSubscriptions();
            enemy1.Fire();
            
            /*
             * Rat game exercise
             */
            var game = new Game();
            var rat1 = new Rat(game);
            var rat2 = new Rat(game);
            
            WriteLine(rat1);
            WriteLine(rat2);
        }

        private static void AccountBalanceUpdated(object sender, AccountBalanceChangedEventArgs e)
        {
            WriteLine($"Account balance change event handled. New balance is: {e.NewBalance}");
        }
    }
}
