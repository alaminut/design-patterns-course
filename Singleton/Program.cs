#region Namespace Imports

using Autofac;
using Singleton.DIContainer;
using Singleton.Lazy;
using Singleton.Naive;
using static System.Console;

#endregion

namespace Singleton
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*
             * Below example uses the most simplest and naive method of implementing Singleton pattern
             * with static class fields holding the instance of that class, and only give access to it
             * via public static Instance property.
             * 
             * Since the ctor of the class is private it is not possible to create an instance of it via new.
             */

            WriteLine(NaiveSingletonDatabase.Instance.GetData());
            WriteLine(NaiveSingletonDatabase.Instance.GetData());

            /*
             * Below example is using System.Lazy<> generic class to lazily instantiate LazySingletonDatabase
             * instance whenever it's Instance property is accessed. Implementation is still Singleton and due to the
             * implementation of System.Lazy it is thread safe.
             */

            WriteLine(LazySingletonDatabase.Instance.GetData());

            /*
             * Below example shows implementing Singleton pattern via dependency injection. In this method
             * class itself is not implemented as singleton, however it is registered as Singleton in the DI container.
             * This way you document that your OrdinaryDatabase class is meant to be used as Singleton without locking
             * the actual class into a singleton implementation.
             */

            var cb = new ContainerBuilder();
            cb.RegisterType<OrdinaryDatabase>().As<IDatabase>().SingleInstance();
            using (var container = cb.Build())
            {
                var ordinaryDb = container.Resolve<IDatabase>();
                var ordinaryDb2 = container.Resolve<IDatabase>();

                WriteLine(ordinaryDb.GetData());
                WriteLine(ordinaryDb2.GetData());
            }
        }
    }
}