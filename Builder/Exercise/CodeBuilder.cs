namespace Builder.Exercise
{
    public class CodeBuilder
    {
        private readonly SyntheticClass _class;

        public CodeBuilder(string className) { _class = new SyntheticClass(className); }

        public CodeBuilder AddField(string fieldName, string fieldType)
        {
            _class.AddField(new SyntheticClassField(fieldType, fieldName));
            return this;
        }

        public override string ToString() { return _class.ToString(); }
    }
}