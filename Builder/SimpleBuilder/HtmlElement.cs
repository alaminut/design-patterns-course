#region Namespace Imports

using System.Collections.Generic;
using System.Text;

#endregion

namespace Builder.SimpleBuilder
{
    public class HtmlElement
    {
        private const int IndentSize = 2;
        public string Tag { get; }
        public string Text { get; }

        public List<HtmlElement> Children { get; } = new List<HtmlElement>();

        public HtmlElement() { }

        public HtmlElement(string tag, string text)
        {
            Tag = tag;
            Text = text;
        }

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var ind = new string(' ', IndentSize * indent);
            sb.AppendLine($"{ind}<{Tag}>");
            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', IndentSize * (indent + 1)));
                sb.Append(Text);
                sb.AppendLine();
            }

            foreach (var child in Children) sb.Append(child.ToStringImpl(indent + 1));

            sb.AppendLine($"{ind}</{Tag}>");
            return sb.ToString();
        }

        public override string ToString() { return ToStringImpl(0); }
    }
}