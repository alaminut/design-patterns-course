#region Namespace Imports

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace SingleResponsibility
{
    public class Journal
    {
        private readonly Dictionary<string, string> _entries = new Dictionary<string, string>();

        public void AddEntry(string entry) { _entries.Add(Guid.NewGuid().ToString("N"), entry); }
        public void AddEntry(string key, string entry) { _entries.Add(key, entry);}

        public override string ToString()
        {
            return string.Join(Environment.NewLine, _entries.Select(x => $"{x.Key}: {x.Value}"));
        }
    }
}