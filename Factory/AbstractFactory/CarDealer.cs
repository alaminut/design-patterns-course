namespace Factory.AbstractFactory
{
    public class CarDealer
    {
        // in a real world example, instead of hard-coding available factories
        // the developer should use dependency injection, or reflection to
        // resolve available factories so that open/closed principle can be uphold.

        private ICarFactory _factory;

        public ICar BuySportsVehicle()
        {
            _factory = new SportsCarFactory();
            return _factory.GetVehicle();
        }

        public ICar BuyMuscleVehicle()
        {
            _factory = new MuscleCarFactory();
            return _factory.GetVehicle();
        }
    }
}
