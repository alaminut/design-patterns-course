#region Namespace Imports

using System.Collections;
using System.Collections.Generic;

#endregion

namespace Composite.Exercise
{
    public class SingleValue : IValueContainer
    {
        public int Value;
        public IEnumerator<int> GetEnumerator() { yield return Value; }

        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }
}