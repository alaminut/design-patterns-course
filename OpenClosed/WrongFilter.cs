using System.Collections.Generic;

namespace OpenClosed
{
    public class WrongFilter
    {
        public static IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var product in products)
            {
                if (product.Color == color)
                    yield return product;
            }
        }

        public static IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var product in products)
            {
                if (product.Size == size)
                    yield return product;
            }
        }
    }
}