namespace InterfaceSegregation
{
    public class SimplePrinter : IMachine
    {
        public void Print()
        {
            /* can print */
        }

        public void Scan()
        {
            /* can not scan, so implementing this method feels wrong. What do we do here? Throw exception? Log? Show a message? */
        }

        public void Fax()
        {
            /* can not send fax, so implementing this method feels wrong. What do we do here? Throw exception? Log? Show a message? */
        }
    }
}