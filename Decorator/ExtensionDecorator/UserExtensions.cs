#region Namespace Imports

using Decorator.DynamicDecorator;

#endregion

namespace Decorator.ExtensionDecorator
{
    /*
     * This is just a C# specific demonstration of
     * using extension methods to decorate existing types.
     * This approach is better suited for adding functionality rather than
     * extending the interface of the object as with this approach we can't
     * add fields or properties to the object itself.
     */
    public static class UserExtensions
    {
        public static bool IsAdult(this IUser self) { return self.Age > 18; }

        /*
         * Despite the explanation of not being able to add properties or
         * fields with extension methods, we can still use extension methods
         * and simple decorator approach together to create helpers to get
         * decorated version of an object.
         */

        public static VipUser ConvertToVip(this IUser self, string lastName)
        {
            /* VipUser implements IUser as well this means this extension
             is available for that class as well. If this is somehow a concern
             to the implementation, concrete class can be used as self parameter
             instead of the interface.
             */
            return new VipUser(self, lastName);
        }
    }
}