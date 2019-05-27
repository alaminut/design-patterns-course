namespace Bridge.DecoupledScheduler
{
    public interface IPlatformScheduler
    {
        void Schedule(string threadName);
    }
}