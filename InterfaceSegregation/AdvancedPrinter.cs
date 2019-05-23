namespace InterfaceSegregation
{
    public class AdvancedPrinter : IAdvancedPrinter
    {
        private readonly IPrint _printer;
        private readonly IScan _scanner;

        public void Scan() { _scanner.Scan(); }
        public void Print() { _printer.Print(); }

        public AdvancedPrinter(IPrint printer, IScan scanner)
        {
            _printer = printer;
            _scanner = scanner;
        }
    }
}