#region Namespace Imports

using Bridge.CoupledScheduler;
using Bridge.DecoupledScheduler;
using Bridge.Exercise;
using static System.Console;

#endregion

namespace Bridge
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*
             * In this example we see the highly coupled implementation of a psuedo ThreadScheduler
             * for different platforms. The problem with this approach is for every variation of ThreadScheduler
             * every platform needs to implement their variations as well.
             */

            var winpts = new WindowsPTS();
            winpts.Schedule("Windows PT#1");
            var wincts = new WindowsCTS();
            wincts.Schedule("Windows CT#1");
            var nixpts = new UnixPTS();
            nixpts.Schedule("Unix PT#1");
            var nixcts = new UnixCTS();
            nixcts.Schedule("Unix CT#1");

            /*
             * The example below illustrates a better way of implementing this ThreadScheduler by using
             * the bridge pattern. We seperate variations of ThreadScheduler, and implemented a parameterized
             * ctor for each variation of ThreadScheduler (in base class) that requires the platform scheduler.
             * This way platform schedulers does not need to extends any scheduler variation.
             */

            var winplatform = new WindowsPlatform();
            var nixplatform = new UnixPlatform();

            var pts = new PreemptiveThreadScheduler(winplatform);
            var cts = new CooperativeScheduler(nixplatform);

            pts.Schedule("Windows Thread #1");
            cts.Schedule("Unix Thread #1");

            /*
             * Below is the course example of Bridge pattern in which we required to refactor a
             * psuedo renderer that is capable of rendering objects in various forms.
             */

            var vrenderer = new VectorRenderer();
            var rrenderer = new RasterRenderer();

            var square = new Square(vrenderer);
            WriteLine(square);
            square.Renderer = rrenderer;
            WriteLine(square);

            var triangle = new Triangle(vrenderer);
            WriteLine(triangle);
            triangle.Renderer = rrenderer;
            WriteLine(triangle);
        }
    }
}