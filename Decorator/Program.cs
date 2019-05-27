#region Namespace Imports

using Decorator.DynamicDecorator;
using Decorator.Exercise;
using Decorator.ExtensionDecorator;
using Decorator.SimpleDecorator;
using static System.Console;

#endregion

namespace Decorator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*
             * In this example we have a simple decorator which extends StringBuilder
             * type of .Net and add it the functionality of string concatenation by += operator
             * and implicit conversion from string to it's type.
             */
            var assignableSb = new AssignableStringBuilder();
            assignableSb = "Hello";
            assignableSb += " World";
            WriteLine(assignableSb);

            /*
             * Decorator pattern is used to add or extend functionality of an
             * existing type. In this example we decorate the basic User class
             * to have a last name when it becomes a VipUser.
             */

            var user = new User("John", 24);
            var vipUser = new VipUser(user, "Doe");

            WriteLine(user);
            WriteLine(vipUser);

            /*
             * Demonstration of C# extension methods to apply decorator pattern.
             */
            var user2 = new User("Jane", 17);
            var ageInfo = user2.IsAdult() ? "an adult" : "not an adult";
            WriteLine($"{user2} is {ageInfo}");

            var vipUser2 = user2.ConvertToVip("Doe");
            WriteLine($"{vipUser2} is a VIP user now.");
            
            /*
             * Course exercise
             */
            var dragon = new Dragon() {Age = 0};
            WriteLine(dragon.Fly());
            WriteLine(dragon.Crawl());
        }
    }
}