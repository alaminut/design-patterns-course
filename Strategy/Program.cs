using Strategy.Dynamic;
using Strategy.Static;
using static System.Console;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            var dl = new DynamicList(new HtmlListRenderStrategy());
            dl.Add("foo");
            dl.Add("bar");
            dl.Add("baz");
            
            WriteLine(dl);
            dl.ChangeRenderStrategy(new MarkdownListRenderStrategy());
            WriteLine(dl);

            var htmlList = new StaticList<HtmlListRenderStrategy>();
            htmlList.Add("item 1");
            htmlList.Add("item 2");
            htmlList.Add("item 3");
            WriteLine(htmlList);
            
            var mdList = new StaticList<MarkdownListRenderStrategy>();
            mdList.Add("item 1");
            mdList.Add("item 2");
            mdList.Add("item 3");
            WriteLine(mdList);
        }
    }
}
