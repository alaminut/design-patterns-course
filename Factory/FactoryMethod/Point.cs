using System;

namespace Factory.FactoryMethod
{
    public class Point
    {
        public double X, Y;

        private Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
        }

        public static Point FromCartesianCoordinates(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point FromPolarCoordinates(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
    }
}
