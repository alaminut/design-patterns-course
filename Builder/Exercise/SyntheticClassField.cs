namespace Builder.Exercise
{
    public class SyntheticClassField
    {
        public string Type { get; }
        public string Name { get; }

        public SyntheticClassField(string type, string name)
        {
            Type = type;
            Name = name;
        }

        public override string ToString() { return $"public {Type} {Name};"; }
    }
}