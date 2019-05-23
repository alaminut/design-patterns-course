namespace Builder.FluentBuilder.RecursiveGeneric
{
    public class PersonInfoBuilder<TSelf> : PersonBuilder<PersonInfoBuilder<TSelf>>
        where TSelf : PersonInfoBuilder<TSelf>
    {
        public TSelf WithName(string name)
        {
            Person.Name = name;
            return (TSelf) this;
        }
    }
}