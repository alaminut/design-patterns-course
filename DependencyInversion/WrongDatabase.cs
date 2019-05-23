#region Namespace Imports

using System.Collections.Generic;

#endregion

namespace DependencyInversion
{
    public class WrongDatabase
    {
        private readonly Dictionary<string, string> _data = new Dictionary<string, string>();
        public Dictionary<string, string> Data => _data;

        public void AddData(string key, string value) { _data.Add(key, value); }
    }
}