using System;

namespace Proxy.ProtectionProxy
{
    public enum PaymentMethod
    {
        MasterCard,
        Visa
    }

    public class BillingProxy : IBillingProcessor
    {
        private readonly PaymentMethod _paymentMethod;
        private readonly IBillingProcessor _processor;

        public BillingProxy(PaymentMethod paymentMethod)
        {
            _paymentMethod = paymentMethod;
            _processor = new BillingProcessor();
        }

        public void AcceptPayment(decimal amount)
        {
            /*
             * In this example we inherit the same interface as the original BillingProcessor class
             * which enables our clients to use our Proxy in place of the original class. But, with this
             * proxy we apply some protection logic to prevent payments to be made with negative amount and
             * allow payments to be made with MasterCard only.
             */
            if (amount < 0)
                throw new Exception("You can not make negative payments.");

            if (_paymentMethod != PaymentMethod.MasterCard)
                throw new Exception($"Your payment method {_paymentMethod} is not supported");

            _processor.AcceptPayment(amount);
        }
    }
}
