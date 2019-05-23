namespace OpenClosed
{
    public enum Color
    {
        Red,
        Green,
        Blue,
        Yellow
    }

    public enum Size
    {
        Small,
        Medium,
        Large,
        Huge
    }

    public class Product
    {
        public string Name { get; }
        public Color Color { get; }
        public Size Size { get; }

        public Product(string name, Color color, Size size)
        {
            Name = name;
            Color = color;
            Size = size;
        }
    }
}