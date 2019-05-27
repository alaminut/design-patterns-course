#region Namespace Imports

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Composite.DrawingLibrary
{
    public enum Color
    {
        None,
        Red,
        Green,
        Blue,
        Yellow
    }

    public class GraphicObject
    {
        private readonly Lazy<ICollection<GraphicObject>> _children =
            new Lazy<ICollection<GraphicObject>>(() => new List<GraphicObject>());

        public virtual string Name { get; }
        public Color Color { get; protected set; } = Color.None;
        public IEnumerable<GraphicObject> Children => _children.Value;

        public GraphicObject() : this("Group") { }

        public GraphicObject(string name) { Name = name; }

        public GraphicObject AddChildren(GraphicObject child)
        {
            _children.Value.Add(child);
            return this;
        }

        private string ToStringImpl(StringBuilder sb, int depth)
        {
            sb.Append(new string('*', depth))
              .Append($"Graphic object: {Name}")
              .AppendLine(Color == Color.None ? string.Empty : $", has {Color} color");

            foreach (var child in Children) child.ToStringImpl(sb, depth+1);

            return sb.ToString();
        }

        public override string ToString() { return ToStringImpl(new StringBuilder(), 0); }
    }

    public class Rectangle : GraphicObject
    {
        public override string Name => "Rectangle";
        public Rectangle(Color color) { Color = color; }
    }

    public class Square : GraphicObject
    {
        public override string Name => "Square";
        public Square(Color color) { Color = color; }
    }
}