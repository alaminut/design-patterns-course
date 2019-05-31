using System;

namespace ChainOfResponsibility.BrokerChain
{
    public class CarGame
    {
        public event EventHandler<Query> Queries;

        public void Query(object sender, Query q)
        {
            Queries?.Invoke(sender, q);
        }
    }
}
