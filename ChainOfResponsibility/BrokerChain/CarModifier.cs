using System;

namespace ChainOfResponsibility.BrokerChain
{
    public abstract class CarModifier : IDisposable
    {
        protected CarGame Game;
        protected Car Car;

        protected abstract void Handle(object sender, Query q);

        protected CarModifier(CarGame game, Car car)
        {
            Game = game;
            Car = car;
            Game.Queries += Handle;
        }

        public void Dispose()
        {
            Game.Queries -= Handle;
        }
    }
}
