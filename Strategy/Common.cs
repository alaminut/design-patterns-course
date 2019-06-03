using System.Collections.Generic;
using System.Text;

namespace Strategy
{
    public interface IListRenderStrategy
    {
        void BuildList(StringBuilder sb, IEnumerable<string> items);
    }

    public class HtmlListRenderStrategy : IListRenderStrategy
    {
        public void BuildList(StringBuilder sb, IEnumerable<string> items)
        {
            sb.AppendLine("<ul>");
            foreach (var item in items)
                sb.AppendLine($"    <li>{item}</li>");

            sb.AppendLine("</ul>");
        }
    }
    
    public class MarkdownListRenderStrategy : IListRenderStrategy
    {
        public void BuildList(StringBuilder sb, IEnumerable<string> items)
        {
            foreach (var item in items)
                sb.AppendLine($"* {item}");
        }
    }
}
