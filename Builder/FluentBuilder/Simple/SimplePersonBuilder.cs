namespace Builder.FluentBuilder.Simple
{
    public class SimplePersonBuilder
    {
        private readonly Person _person = new Person();

        public SimplePersonBuilder WithName(string name)
        {
            _person.Name = name;
            return this;
        }

        public SimplePersonBuilder WithPosition(string position)
        {
            _person.Position = position;
            return this;
        }

        public Person Build() { return _person; }
    }
}