namespace Proxy.ValueProxy
{
    public struct Percentage
    {
        private readonly float _value;

        public Percentage(float value)
        {
            _value = value;
        }

        public static Percentage operator +(Percentage left, Percentage right)
        {
            return new Percentage(left._value + right._value);
        }

        public static float operator *(float left, Percentage right)
        {
            return left * right._value;
        }

        public override string ToString()
        {
            return $"{_value * 100}%";
        }
    }
}
