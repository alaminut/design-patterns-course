namespace Proxy.ValueProxy
{
    public static class PercentProxy
    {
        /*
         * In this type of proxy we are creating an extension method
         * for integer data type (a value type) which can be described as
         * a value proxy.
         */
        public static Percentage Percent(this int value)
        {
            return new Percentage(value / 100.0f);
        }
    }
}
