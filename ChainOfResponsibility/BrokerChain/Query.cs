using System;
using System.Linq.Expressions;

namespace ChainOfResponsibility.BrokerChain
{
    public class Query
    {
        public Expression<Func<Car, int>> PropertySelector { get; private set; }
        public int Value { get; set; }

        public Query(Expression<Func<Car, int>> propertySelector, int value)
        {
            PropertySelector = propertySelector;
            Value = value;
        }
    }
}
