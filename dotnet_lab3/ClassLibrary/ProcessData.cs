namespace ClassLibrary
{
    public class ProcessData
    {
        public string Name { get; }
        public long MemoryUsed { get; }
        public string StartTime { get; }
        public int Priority { get; }
        public int ThreadCount { get; }

        public ProcessData(string name, long memoryUsed, string startTime, int priority, int threadCount)
        {
            Name = name;
            MemoryUsed = memoryUsed;
            StartTime = startTime;
            Priority = priority;
            ThreadCount = threadCount;
        }
    }
}