namespace Builder.Facade
{
    public class PersonalInformationBuilder : EmployeeBuilder
    {
        public PersonalInformationBuilder(Employee employee) { Employee = employee; }

        public PersonalInformationBuilder As(string name)
        {
            Employee.PersonalInformation.Name = name;
            return this;
        }

        public PersonalInformationBuilder ForYears(int age)
        {
            Employee.PersonalInformation.Age = age;
            return this;
        }
    }
}