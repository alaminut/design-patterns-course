namespace Adapter
{
    public class SquareToRectangleAdapter : IRectangle
    {
        public int Width { get; }
        public int Height { get; }

        public int Area() { return Width * Height; }

        public SquareToRectangleAdapter(Square square) { Width = Height = square.Side; }
    }
}