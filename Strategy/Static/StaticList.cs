using System.Collections.Generic;
using System.Text;

namespace Strategy.Static
{
    public class StaticList<TRenderStrategy> : List<string> where TRenderStrategy : class, IListRenderStrategy, new()
    {
        private readonly IListRenderStrategy _strategy = new TRenderStrategy();

        public override string ToString()
        {
            var sb = new StringBuilder();
            _strategy.BuildList(sb, this);
            return sb.ToString();
        }
    }
}
