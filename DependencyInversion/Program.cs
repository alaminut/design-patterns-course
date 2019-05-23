#region Namespace Imports

using static System.Console;

#endregion

namespace DependencyInversion
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // According to the Dependency Inversion principle
            // a high-level code should not depend on low-level code directly
            // instead low-level code should introduce an abstraction to access it's internals.

            // In this example we see a WrongDatabase class, simulating a simple key-value pair database
            // and a SadDatabaseClient class simulating a database query to find records by their key. WrongDatabase
            // has to provide a public property to it's internal storage in order for SadDatabaseClient to work, however
            // this leads developer to prevent changing WrongDatabase class' internal storage logic as that would
            // break the high-level DatabaseQuery class.

            var wrongDatabase = new WrongDatabase();
            wrongDatabase.AddData("d1", "A bad way to implement database");

            var sadClient = new SadDatabaseClient(wrongDatabase);
            WriteLine(sadClient.GetByKey("d1"));

            // Next example introduces a BetterDatabase class which implements an interface IQueryByKey
            // this abstraction enables it's internals to stay private and not leak outside, and implementors
            // can only depend on this abstraction (interface) in order to work with BetterDatabase.
            // This way if BetterDatabase decides to store data in a different format, implementors would not have to
            // change.

            var betterDatabase = new BetterDatabase();
            betterDatabase.AddData("b1", "This is a better way to implement database");

            var happyClient = new HappyDatabaseClient(betterDatabase);
            WriteLine(happyClient.GetByKey("b1"));
        }
    }
}