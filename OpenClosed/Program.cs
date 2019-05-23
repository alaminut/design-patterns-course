#region Namespace Imports

using static System.Console;

#endregion

namespace OpenClosed
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var products = new[]
            {
                new Product("Coffee Table", Color.Yellow, Size.Large),
                new Product("iPhone 6S", Color.Blue, Size.Small),
                new Product("Tesla Model S", Color.Green, Size.Large), new Product("House", Color.Red, Size.Huge),
                new Product("Chair", Color.Green, Size.Medium)
            };

            // WrongFilter class is an example of violation of Open / Closed principle.
            // According to the principle, if we have a tested, working class, in order to
            // introduce a new functionality we shall not have to modify the class, but, extend it
            // by using various methods / patterns.

            // In this example, WrongFilter class can perfectly filter products by their color
            // or size with it's two methods. Problem arises when we need to introduce new functionality
            // like "Filter by color and size". With the current iteration, we have to change WrongFilter class
            // and introduce a new method to it. This violates the Open / Closed principle.
            foreach (var product in WrongFilter.FilterByColor(products, Color.Green))
                WriteLine($"{product.Name} is a {product.Color} product");

            // With open / closed principle in mind, we created a new class called BetterFilter.
            // this class implements specification pattern and instead of bringing methods for individual
            // filtering actions, it introduces interfaces to define filtering specifications and a filter
            // method using those specifications.

            // With this approach, we can easily introduce new filtering mechanisms without ever touching BetterFilter
            // class and by simply creating new ISpecification<T> implementation for requirements.
            var filter = new BetterFilter();
            foreach (var product in filter.Filter(products, new ColorSpecification(Color.Blue)))
                WriteLine($"{product.Name} is a {product.Color} product");

            // In this example we filter Green and Medium products.
            foreach (var product in filter.Filter(products,
                                                  new AndSpec<Product>(new ColorSpecification(Color.Green),
                                                                       new SizeSpecification(Size.Medium))))
                WriteLine($"{product.Name} is a {product.Color} and {product.Size} product");
        }
    }
}