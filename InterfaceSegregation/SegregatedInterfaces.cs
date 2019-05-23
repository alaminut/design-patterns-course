namespace InterfaceSegregation
{
    public interface IPrint
    {
        void Print();
    }

    public interface IScan
    {
        void Scan();
    }

    public interface IAdvancedPrinter : IPrint, IScan
    {
    }
}