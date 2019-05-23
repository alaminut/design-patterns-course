namespace DependencyInversion
{
    public class HappyDatabaseClient
    {
        private readonly IQueryByKey _database;

        public HappyDatabaseClient(IQueryByKey database) { _database = database; }

        public string GetByKey(string key) { return _database.GetByKey(key); }
    }
}