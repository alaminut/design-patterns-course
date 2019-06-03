using System.Collections.Generic;
using System.Text;

namespace Strategy.Dynamic
{
    public class DynamicList : List<string>
    {
        private IListRenderStrategy _renderStrategy;

        public DynamicList(IListRenderStrategy renderStrategy)
        {
            _renderStrategy = renderStrategy;
        }

        public void ChangeRenderStrategy(IListRenderStrategy strategy)
        {
            _renderStrategy = strategy;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            _renderStrategy.BuildList(sb, this);
            return sb.ToString();
        }
    }
}
