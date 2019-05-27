namespace Decorator
{
    public interface IUser
    {
        string Name { get; }
        int Age { get; }
    }

    // Using sealed class here in order to simulate inheritance is not possible.
    public sealed class User : IUser
    {
        public string Name { get; }
        public int Age { get; }

        public User(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString() { return $"{Name}"; }
    }
}