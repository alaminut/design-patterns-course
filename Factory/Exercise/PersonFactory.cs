namespace Factory.Exercise
{
    public class PersonFactory
    {
        private static int _nextId = 0;

        public Person CreatePerson(string name)
        {
            return new Person(_nextId++, name);
        }
    }
}
