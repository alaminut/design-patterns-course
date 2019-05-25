using System;
using Factory.AbstractFactory;
using Factory.Exercise;
using Factory.FactoryClass;
using Factory.FactoryMethod;
using static System.Console;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            // The first and most simplest approach to a factory pattern is
            // factory method. This is simply achieved by static methods inside a class
            // and private constructor so that the class can not be instantiated outside of
            // the factory methods.
            
            // Below example illustrates creating a Point object from it's two different factory
            // methods.

            var p1 = Point.FromCartesianCoordinates(1, 2);
            WriteLine(p1);
            var p2 = Point.FromPolarCoordinates(100, Math.PI / 2);
            WriteLine(p2);
            
            // Below example is using a Factory Class instead of factory method.
            // Sometimes using a factory method may not be desired because it is
            // possibly violating Single Responsibility / Seperation of Concerns patterns.
            // In that case, you delegate object creation to a different class.

            var m1 = Material.Factory.CreateSilk();
            WriteLine(m1);
            var m2 = Material.Factory.CreateMetal();
            WriteLine(m2);
            
            // Below example is using abstract factory pattern in which types are
            // interfaces and resolved during runtime according to the type of object client
            // is attempting to create.

            var dealer = new CarDealer();
            var c1 = dealer.BuySportsVehicle();
            c1.Drive();
            var c2 = dealer.BuyMuscleVehicle();
            c2.Drive();

            var pf = new PersonFactory();
            for (var i = 0; i < 5; i++)
            {
                var person = pf.CreatePerson($"Random Name {i + 1}");
                WriteLine(person);
            }
        }
    }
}
