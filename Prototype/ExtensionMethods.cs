#region Namespace Imports

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

#endregion

namespace Prototype
{
    /*
     * In this implementation example of Prototype pattern
     * we choose the Extension method C# specific feature
     * to implement generic DeepCopy() method implementing
     * binary serialization. One caveat of this method is that
     * the class we want to DeepCopy() must have Serializable attribute
     */
    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, self);
                ms.Seek(0, SeekOrigin.Begin);
                return (T) formatter.Deserialize(ms);
            }
        }
    }
}