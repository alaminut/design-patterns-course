#region Namespace Imports

using System.Collections.Generic;

#endregion

namespace Composite.Exercise
{
    public static class ExtensionMethods
    {
        public static int Sum(this List<IValueContainer> containers)
        {
            var result = 0;
            foreach (var c in containers)
            foreach (var value in c)
                result += value;

            return result;
        }
    }
}