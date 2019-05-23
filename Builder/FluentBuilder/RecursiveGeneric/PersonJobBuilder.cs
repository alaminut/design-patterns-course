namespace Builder.FluentBuilder.RecursiveGeneric
{
    public class PersonJobBuilder<TSelf> : PersonInfoBuilder<PersonJobBuilder<TSelf>>
        where TSelf : PersonJobBuilder<TSelf>
    {
        public TSelf WithPosition(string position)
        {
            Person.Position = position;
            return (TSelf) this;
        }
    }
}