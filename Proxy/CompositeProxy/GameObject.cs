namespace Proxy.CompositeProxy
{
    public class GameObject
    {
        public byte Age { get; }
        public int X { get; }
        public int Y { get; }

        public GameObject(byte age, int x, int y)
        {
            Age = age;
            X = x;
            Y = y;
        }
    }
}
