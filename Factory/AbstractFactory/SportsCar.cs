using System;

namespace Factory.AbstractFactory
{
    internal class SportsCar : ICar
    {
        public void Drive()
        {
            Console.WriteLine($"I am a sports car and I go super fast!");
        }
    }
}
