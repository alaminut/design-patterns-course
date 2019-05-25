using System;

namespace Factory.AbstractFactory
{
    internal class MuscleCar : ICar
    {
        public void Drive()
        {
            Console.WriteLine("I'm a muscle car, I have super cool engine sound!");
        }
    }
}
