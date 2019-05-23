namespace Builder.SimpleBuilder
{
    public class HtmlBuilder
    {
        private readonly string _rootTag;
        private HtmlElement _root;

        public HtmlBuilder(string rootTag)
        {
            _rootTag = rootTag;
            _root = new HtmlElement(_rootTag, null);
        }

        public void AppendChild(string tag, string text) { _root.Children.Add(new HtmlElement(tag, text)); }

        public void Clear() { _root = new HtmlElement(_rootTag, null); }

        public override string ToString() { return _root.ToString(); }
    }
}