namespace Builder.Facade
{
    public class AddressBuilder : EmployeeBuilder
    {
        public AddressBuilder(Employee employee) { Employee = employee; }

        public AddressBuilder In(string country)
        {
            Employee.Address.Country = country;
            return this;
        }

        public AddressBuilder At(string street)
        {
            Employee.Address.Street = street;
            return this;
        }

        public AddressBuilder WithPostalCode(int zipCode)
        {
            Employee.Address.ZipCode = zipCode;
            return this;
        }
    }
}