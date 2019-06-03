using System;
using System.Numerics;

namespace Strategy.Exercise
{
    public interface IDiscriminantStrategy
    {
        double CalculateDiscriminant(double a, double b, double c);
    }

    public abstract class DiscriminantStrategy : IDiscriminantStrategy
    {
        public virtual double CalculateDiscriminant(double a, double b, double c)
        {
            return b * b - 4 * a * c;
        }
    }

    public class OrdinaryDiscriminantStrategy : DiscriminantStrategy
    {
        // do nothing as we return the discriminant as-is
    }

    public class RealDiscriminantStrategy : DiscriminantStrategy
    {
        public override double CalculateDiscriminant(double a, double b, double c)
        {
            var d = base.CalculateDiscriminant(a, b, c);
            return d < 0 ? double.NaN : d;
        }
    }

    public class QuadraticEquationSolver
    {
        private readonly IDiscriminantStrategy strategy;

        public QuadraticEquationSolver(IDiscriminantStrategy strategy)
        {
            this.strategy = strategy;
        }

        public Tuple<Complex, Complex> Solve(double a, double b, double c)
        {
            var d = strategy.CalculateDiscriminant(a, b, c);
            var rd = Complex.Sqrt(d);
            return Tuple.Create((-b + rd) / (2 * a), (-b - rd) / (2 * a));
        }
    }
}
