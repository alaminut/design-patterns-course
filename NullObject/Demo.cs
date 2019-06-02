using System;

namespace NullObject
{
    public interface ILog
    {
        // maximum # of elements in the log
        int RecordLimit { get; }
    
        // number of elements already in the log
        int RecordCount { get; set; }

        // expected to increment RecordCount
        void LogInfo(string message);
    }

    public class Account
    {
        private ILog log;

        public Account(ILog log)
        {
            this.log = log;
        }

        public void SomeOperation()
        {
            int c = log.RecordCount;
            log.LogInfo("Performing an operation");
            if (c+1 != log.RecordCount)
                throw new Exception();
            if (log.RecordCount >= log.RecordLimit)
                throw new Exception();
        }
    }

    /*
     * This is an example of null object. Instead of
     * providing real functionality to the implemented interface members
     * we simply mute them all so that dependants on this interface can still
     * work without null reference exceptions.
     */
    public class NullLog : ILog
    {
        private int _recordCount = 0;
        public int RecordLimit => _recordCount + 1;

        public int RecordCount
        {
            get => _recordCount;
            set
            {
                //
            }
        }
        public void LogInfo(string message)
        {
            ++_recordCount;
        }
    }
}
