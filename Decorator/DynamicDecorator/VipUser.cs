namespace Decorator.DynamicDecorator
{
    /* This example simply to show extending a sealed class
     by using decorator approach. This class defines a new user type
     which decorates on the existing user type that is capable of having
     a last name property. This is a dynamic decorator approach
     since it is applied on the runtime rather than design time.
     */
    public class VipUser : IUser
    {
        private readonly IUser _user;
        public string Lastname { get; }

        public string Name => _user.Name;
        public int Age => _user.Age;

        public VipUser(IUser user, string lastName)
        {
            _user = user;
            Lastname = lastName;
        }

        public override string ToString() { return $"{_user} {Lastname}"; }
    }
}