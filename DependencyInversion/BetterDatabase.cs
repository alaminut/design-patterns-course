#region Namespace Imports

using System.Collections.Generic;

#endregion

namespace DependencyInversion
{
    public interface IQueryByKey
    {
        string GetByKey(string key);
    }

    public class BetterDatabase : IQueryByKey
    {
        public Dictionary<string, string> _data = new Dictionary<string, string>();

        public string GetByKey(string key) { return _data[key]; }

        public void AddData(string key, string value) { _data.Add(key, value); }
    }
}