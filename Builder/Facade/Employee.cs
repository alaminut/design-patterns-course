namespace Builder.Facade
{
    public class JobInformation
    {
        public string Position { get; set; }
        public decimal AnnualSalary { get; set; }

        public override string ToString()
        {
            return $"{nameof(Position)}: {Position}, {nameof(AnnualSalary)}: {AnnualSalary}";
        }
    }

    public class PersonalInformation
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString() { return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}"; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string Country { get; set; }
        public int ZipCode { get; set; }

        public override string ToString()
        {
            return $"{nameof(Street)}: {Street}, {nameof(Country)}: {Country}, {nameof(ZipCode)}: {ZipCode}";
        }
    }

    public class Employee
    {
        public PersonalInformation PersonalInformation { get; set; }
        public JobInformation JobInformation { get; set; }
        public Address Address { get; set; }

        public Employee()
        {
            PersonalInformation = new PersonalInformation();
            JobInformation = new JobInformation();
            Address = new Address();
        }

        public override string ToString()
        {
            return
                $"{nameof(PersonalInformation)}: {PersonalInformation}, {nameof(JobInformation)}: {JobInformation}, {nameof(Address)}: {Address}";
        }
    }
}