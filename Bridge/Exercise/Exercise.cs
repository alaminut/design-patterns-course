namespace Bridge.Exercise
{
    public interface IRenderer
    {
        string WhatToRenderAs { get; }
    }

    public abstract class Shape
    {
        public IRenderer Renderer;
        public string Name { get; set; }
        protected Shape(IRenderer renderer) { Renderer = renderer; }
    }

    public class Triangle : Shape
    {
        public Triangle(IRenderer renderer) : base(renderer) { Name = "Triangle"; }
        public override string ToString() { return $"Drawing {Name} as {Renderer.WhatToRenderAs}"; }
    }

    public class Square : Shape
    {
        public Square(IRenderer renderer) : base(renderer) { Name = "Square"; }
        public override string ToString() { return $"Drawing {Name} as {Renderer.WhatToRenderAs}"; }
    }

    public class RasterRenderer : IRenderer
    {
        public string WhatToRenderAs { get; } = "pixels";
    }

    public class VectorRenderer : IRenderer
    {
        public string WhatToRenderAs { get; } = "lines";
    }
}