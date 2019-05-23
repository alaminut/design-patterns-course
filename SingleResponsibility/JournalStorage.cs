#region Namespace Imports

using System;
using System.IO;

#endregion

namespace SingleResponsibility
{
    public class JournalStorage
    {
        public static void Save(Journal journal, string fileName, bool overwrite = false)
        {
            if (!File.Exists(fileName) || overwrite)
                File.WriteAllText(fileName, journal.ToString());
        }

        public static Journal Load(string fileName)
        {
            var journal = new Journal();
            if (File.Exists(fileName))
            {
                var contents = File.ReadAllText(fileName);
                var entries = contents.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
                foreach (var entry in entries)
                {
                    var keyValuePair = entry.Split(':');
                    journal.AddEntry(keyValuePair[0], keyValuePair[1].Trim());
                }
            }

            return journal;
        }
    }
}