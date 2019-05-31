using System.Linq.Expressions;

namespace ChainOfResponsibility.BrokerChain
{
    public class DoubleSpeedModifier : CarModifier
    {
        public const string ModifiedAttribute = "MaxSpeed";
        public DoubleSpeedModifier(CarGame game, Car car) : base(game, car) { }

        protected override void Handle(object sender, Query q)
        {
            if (q.PropertySelector.Body is MemberExpression p && p.Member.Name == ModifiedAttribute)
            {
                q.Value *= 2;
            }
        }
    }
}
