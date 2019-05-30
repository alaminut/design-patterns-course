using System;

namespace Proxy.ProtectionProxy
{
    public class BillingProcessor : IBillingProcessor
    {
        public void AcceptPayment(decimal amount)
        {
            Console.WriteLine($"Payment accepted: {amount}");
        }
    }
}
