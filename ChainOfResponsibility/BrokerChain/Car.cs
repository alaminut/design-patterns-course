namespace ChainOfResponsibility.BrokerChain
{
    public class Car
    {
        private CarGame _game;
        private int _maxSpeed = 100;
        
        public Car(CarGame game)
        {
            _game = game;
        }

        public int MaxSpeed
        {
            get
            {
                var q = new Query(c => c.MaxSpeed, _maxSpeed);
                _game.Query(this, q);
                return q.Value;
            }
        }

        public override string ToString()
        {
            return $"{nameof(MaxSpeed)}: {MaxSpeed}";
        }
    }
}
