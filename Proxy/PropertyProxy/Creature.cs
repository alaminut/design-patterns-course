namespace Proxy.PropertyProxy
{
    public class Creature
    {
        private readonly Property<int> _agility = new Property<int>();
        public string Name { get; set; }

        public int Agility
        {
            get => _agility.Value;
            set => _agility.Value = value;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Agility)}: {Agility}";
        }
    }
}
