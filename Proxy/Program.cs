using System;
using Proxy.CompositeProxy;
using Proxy.DynamicProxy;
using Proxy.Exercise;
using Proxy.PropertyProxy;
using Proxy.ProtectionProxy;
using Proxy.ValueProxy;
using static System.Console;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            /* This example demonstrates using a proxy as a protection.
             * Below you'll see the original usage of sample billing processor
             * which allows negative payments, plus does not care about the billing method.
             */
            
            IBillingProcessor processor;
            processor = new BillingProcessor();
            processor.AcceptPayment(-500M);
            processor.AcceptPayment(-5.0M);
            
            /*
             * This is the usage of proxy as a protection layer on top of the existing class
             * proxy both checks the payment method and the amount and if all checks pass, it delegates
             * the call to the original billing proxy object created inside.
             */
            processor = new BillingProxy(PaymentMethod.MasterCard);
            try
            {
                processor.AcceptPayment(1000M);
                processor.AcceptPayment(-5M);
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
            
            /*
             * Example below demonstrates the use of proxy pattern as a property proxy.
             */
            var creature = new Creature(){Name = "Obi-Wan Kenobi"};
            creature.Agility = 100;
            // Below line will not yield a console output.
            creature.Agility = 100;
            WriteLine(creature);
            
            /*
             * Below example demonstrates a value proxy over integer type.
             */
            WriteLine(5.Percent());
            WriteLine(100f * 5.Percent());
            WriteLine(5.Percent() + 10.Percent());
            
            /*
             * This composite proxy pattern implementation demonstrates how to use
             * both patterns to achieve a pseudo memory efficient way of accessing
             * many objects and changing their properties.
             */

            /*
             * Imagine this scenario where you have millions of creatures and want to change
             * their X coordinates in each game tick. Since Creature object has many fields
             * and they have different byte sizes in the memory the instructor would theoretically
             * (without compiler and cpu optimizations) jump unnecessary amount of memory blocks to perform it.  
             */
            
            /*var inefficientCreatures = new GameObject[100];
            foreach (var creature in inefficientCreatures)
            {
                creature.X++;
            }*/
            
            /*
             * With the help of proxy and composite patterns we build a more memory efficient data
             * structure to perform such operation.
             */
            var i = 1;
            var gameObjects = new GameObjects(1000);
            foreach (var gameObject in gameObjects)
            {
                gameObject.X++;
                WriteLine($"Game object {i}: {gameObject}");
                ++i;
            }
            
            /*
             * Below example shows a dynamic proxy which is generated runtime (with the added performance costs)
             * to create a log proxy over any type.
             */

            var ba = new BankAccount(100);
            ba.Withdraw(20);
            ba.Deposit(50);
            WriteLine(ba);

            var loggedAccount = LogProxy<BankAccount>.As<IBankAccount>(100);
            loggedAccount.Withdraw(50);
            loggedAccount.Deposit(15);
            
            // Exercise demo
            var p = new Person() {Age = 21};
            var rp = new ResponsiblePerson(p);
            WriteLine(rp.Drive());
            WriteLine(rp.Drink());
            WriteLine(rp.DrinkAndDrive());
        }
    }
}
