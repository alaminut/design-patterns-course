namespace Prototype.Exercise
{
    public class Point
    {
        public int X, Y;
    }

    public class Line
    {
        public Point Start, End;

        public Line DeepCopy()
        {
            var copy = new Line();
            copy.Start = new Point() {X = Start.X, Y = Start.Y};
            copy.End = new Point() {X = End.X, Y = End.Y};
            return copy;
        }
    }
}