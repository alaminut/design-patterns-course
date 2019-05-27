namespace Adapter
{
    public interface IRectangle
    {
        int Width { get; }
        int Height { get; }
        int Area();
    }
}