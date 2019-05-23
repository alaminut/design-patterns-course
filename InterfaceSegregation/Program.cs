namespace InterfaceSegregation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Interface Segregation principle suggests that an interface should
            // not contain methods that may not be needed for it's inheritors.

            // In this example we see an interface that breaks this principle IMachine
            // which contains methods Print, Scan and Fax. When we implement this interface
            // from a class MultiPurposeMachine it makes sense, however if we decide to implement
            // the same class from a SimplePrinter it does not make sense because SimplePrinter can not
            // perform Scan and Fax actions.

            // Interface Segregation suggests that we should segregate interfaces, make them smaller
            // and use inheritance if we need to create a composition of different interfaces.

            IMachine multiMachine = new MultiPurposeMachine();
            multiMachine.Print(); // this machine is capable of doing it.
            multiMachine.Fax();   // this machine is capable of doing it.
            multiMachine.Scan();  // this machine is capable of doing it.

            IMachine simplePrinter = new SimplePrinter();
            simplePrinter.Print(); // this machine is capable of doing it.
            simplePrinter
                .Scan(); // this was supposed to be a simple printer with print ability. This method does not make sense.
            simplePrinter
                .Fax(); // this was supposed to be a simple printer with print ability. This method does not make sense.

            // Below classes implement segregated interfaces and now we see they don't have
            // irrelevant methods implemented in them. Even better, we are delegating
            // print and scan to their respective classes so we don't repeat ourselves
            // in the AdvancedPrinter class.

            var advancedPrinter = new AdvancedPrinter(new Printer(), new Scanner());
            advancedPrinter.Print(); // can do
            advancedPrinter.Scan();  // can do
        }
    }
}