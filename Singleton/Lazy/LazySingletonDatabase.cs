#region Namespace Imports

using System;

#endregion

namespace Singleton.Lazy
{
    public class LazySingletonDatabase : IDatabase
    {
        private static readonly Lazy<LazySingletonDatabase> _instance =
            new Lazy<LazySingletonDatabase>(() => new LazySingletonDatabase());

        public static LazySingletonDatabase Instance => _instance.Value;

        public string GetData()
        {
            return $"You are using {nameof(LazySingletonDatabase)} singleton instance to read this data";
        }
    }
}