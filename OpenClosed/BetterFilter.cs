#region Namespace Imports

using System.Collections.Generic;

#endregion

namespace OpenClosed
{
    public interface ISpecification<in T>
    {
        bool IsCompliant(T item);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    public class ColorSpecification : ISpecification<Product>
    {
        private readonly Color _color;
        public bool IsCompliant(Product item) { return item.Color == _color; }

        public ColorSpecification(Color color) { _color = color; }
    }

    public class SizeSpecification : ISpecification<Product>
    {
        private readonly Size _size;
        public bool IsCompliant(Product item) { return item.Size == _size; }

        public SizeSpecification(Size size) { _size = size; }
    }

    // Even if we are creating specs, in order to keep open / closed principle valid
    // for those specs we're extending specifications to create more complex specifications.

    public class AndSpec<T> : ISpecification<T>
    {
        private readonly ISpecification<T> _spec1;
        private readonly ISpecification<T> _spec2;

        public bool IsCompliant(T item) { return _spec1.IsCompliant(item) && _spec2.IsCompliant(item); }

        public AndSpec(ISpecification<T> spec1, ISpecification<T> spec2)
        {
            _spec1 = spec1;
            _spec2 = spec2;
        }
    }

    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach (var item in items)
                if (spec.IsCompliant(item))
                    yield return item;
        }
    }
}