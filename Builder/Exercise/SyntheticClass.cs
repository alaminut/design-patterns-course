#region Namespace Imports

using System.Collections.Generic;
using System.Text;

#endregion

namespace Builder.Exercise
{
    public class SyntheticClass
    {
        private const int IndentSize = 2;
        private readonly ICollection<SyntheticClassField> _fields = new List<SyntheticClassField>();
        public string Name { get; }

        public SyntheticClass(string name) { Name = name; }

        public void AddField(SyntheticClassField field) { _fields.Add(field); }

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"public class {Name}");
            sb.AppendLine("{");
            
            foreach (var field in _fields)
            {
                var ind = new string(' ', IndentSize * (indent + 1));
                sb.AppendLine($"{ind}{field}");
            }

            sb.AppendLine("}");
            return sb.ToString();
        }

        public override string ToString() { return ToStringImpl(0); }
    }
}