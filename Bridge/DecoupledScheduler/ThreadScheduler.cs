namespace Bridge.DecoupledScheduler
{
    public abstract class ThreadScheduler
    {
        protected readonly IPlatformScheduler PlatformScheduler;

        protected ThreadScheduler(IPlatformScheduler platformScheduler) { PlatformScheduler = platformScheduler; }

        public abstract void Schedule(string threadName);
    }
}