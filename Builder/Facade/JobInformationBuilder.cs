namespace Builder.Facade
{
    public class JobInformationBuilder : EmployeeBuilder
    {
        public JobInformationBuilder(Employee employee) { Employee = employee; }
        
        public JobInformationBuilder As(string position)
        {
            Employee.JobInformation.Position = position;
            return this;
        }

        public JobInformationBuilder WithSalary(decimal salary)
        {
            Employee.JobInformation.AnnualSalary = salary;
            return this;
        }
    }
}