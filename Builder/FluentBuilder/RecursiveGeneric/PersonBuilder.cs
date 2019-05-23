namespace Builder.FluentBuilder.RecursiveGeneric
{
    /// <summary>
    ///     This is important to understand. This abstract class uses generic recursive inheritance to be able
    ///     to provide a fluent interface. TSelf type parameter will be passed from this class' inheritors all the way
    ///     up to the class itself. This way a PersonBuilder will know about it's inheritance chain
    /// </summary>
    /// <typeparam name="TSelf"></typeparam>
    public abstract class PersonBuilder<TSelf> where TSelf : PersonBuilder<TSelf>
    {
        protected Person Person = new Person();
        public Person Build() { return Person; }
    }
}