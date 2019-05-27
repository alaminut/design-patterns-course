using static System.Console;

namespace Bridge.CoupledScheduler
{
    public abstract class CoupledThreadScheduler
    {
        public abstract void Schedule(string threadName);
    }
    
    public class CoupledPreemptiveScheduler : CoupledThreadScheduler
    {
        public override void Schedule(string threadName) { WriteLine($"Scheduling thread {threadName} preemptive."); }
    }
    public class CoupledCooperativeScheduler : CoupledThreadScheduler
    {
        public override void Schedule(string threadName)
        {
            WriteLine($"Scheduling thread {threadName} cooperatively.");
        }
    }
}