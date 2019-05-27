#region Namespace Imports

using static System.Console;

#endregion

namespace Bridge.DecoupledScheduler
{
    public class UnixPlatform : IPlatformScheduler
    {
        public void Schedule(string threadName) { WriteLine($"Windows Thread {threadName} scheduled."); }
    }
}