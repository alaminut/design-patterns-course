namespace DependencyInversion
{
    public class SadDatabaseClient
    {
        private readonly WrongDatabase _database;

        public SadDatabaseClient(WrongDatabase database) { _database = database; }

        // highly coupled to WrongDatabase, changing it's internal storage
        // will require this method to be updated as well.
        public string GetByKey(string key) { return _database.Data[key]; }
    }
}