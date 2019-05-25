namespace Factory.Exercise
{
    public class Person
    {
        public int Id;
        public string Name;
        
        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}";
        }
    }
}
