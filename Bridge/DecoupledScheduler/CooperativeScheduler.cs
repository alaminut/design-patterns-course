#region Namespace Imports

using static System.Console;

#endregion

namespace Bridge.DecoupledScheduler
{
    public class CooperativeScheduler : ThreadScheduler
    {
        public CooperativeScheduler(IPlatformScheduler platformScheduler) : base(platformScheduler) { }

        public override void Schedule(string threadName)
        {
            WriteLine($"Scheduling thread {threadName} for platform of type {PlatformScheduler.GetType().Name} cooperatively.");
            PlatformScheduler.Schedule(threadName);
        }
    }
}