namespace Factory.AbstractFactory
{
    internal class SportsCarFactory : ICarFactory
    {
        public ICar GetVehicle()
        {
            return new SportsCar();
        }
    }

    internal class MuscleCarFactory : ICarFactory
    {
        public ICar GetVehicle()
        {
            return new MuscleCar();
        }
    }
}
