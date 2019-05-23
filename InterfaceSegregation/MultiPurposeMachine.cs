namespace InterfaceSegregation
{
    public class MultiPurposeMachine : IMachine
    {
        public void Print()
        {
            /* can print */
        }

        public void Scan()
        {
            /* can scan */
        }

        public void Fax()
        {
            /* can send fax */
        }
    }
}