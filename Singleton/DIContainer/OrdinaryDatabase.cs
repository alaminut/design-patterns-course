namespace Singleton.DIContainer
{
    public class OrdinaryDatabase : IDatabase
    {
        private static int _instanceCount;

        public string GetData()
        {
            return $"{nameof(OrdinaryDatabase)} is not a singleton class and has {_instanceCount} instances created.";
        }

        public OrdinaryDatabase() { _instanceCount++; }
    }
}