namespace Singleton.Naive
{
    public class NaiveSingletonDatabase : IDatabase
    {
        public static NaiveSingletonDatabase Instance { get; } = new NaiveSingletonDatabase();

        public static int InstanceCount { get; private set; }

        private NaiveSingletonDatabase() { InstanceCount++; }

        public string GetData()
        {
            return $"{nameof(NaiveSingletonDatabase)} has {InstanceCount} instances instantiated";
        }
    }
}