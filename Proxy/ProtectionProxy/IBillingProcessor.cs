namespace Proxy.ProtectionProxy
{
    public interface IBillingProcessor
    {
        void AcceptPayment(decimal amount);
    }
}
