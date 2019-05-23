namespace Builder.Facade
{
    public class EmployeeBuilder
    {
        protected Employee Employee = new Employee();

        public PersonalInformationBuilder Known => new PersonalInformationBuilder(Employee);
        public AddressBuilder Lives => new AddressBuilder(Employee);
        public JobInformationBuilder Works => new JobInformationBuilder(Employee);

        public Employee Get => Employee;
    }
}