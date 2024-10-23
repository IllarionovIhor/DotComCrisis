using System.Diagnostics;


namespace ClassLibrary
{
	public class ProcessManager
	{
		public class ProcessEventArgs : EventArgs
		{
			public string ProcessName;
			public string Message;

			public ProcessEventArgs(string message, string processName)
			{
				this.Message = message;
				this.ProcessName = processName;
			}
            public ProcessEventArgs(string message)
            {
                this.Message = message;
            }
        }
        Dictionary<int, ProcessPriorityClass> prioDict;

        public ProcessManager()
        {
            prioDict = new Dictionary<int, ProcessPriorityClass>();
            prioDict[4] = ProcessPriorityClass.Idle;
            prioDict[8] = ProcessPriorityClass.Normal;
            prioDict[13] = ProcessPriorityClass.High;
            prioDict[24] = ProcessPriorityClass.RealTime;
        }

		public event EventHandler<ProcessEventArgs> FailedToGetProcess;
		public ProcessData[] getProcessArray()
		{
			List<ProcessData> processData = new List<ProcessData>();
			Process[] processCollection = Process.GetProcesses();
			foreach (Process proc in processCollection)
			{
				try
				{
					processData.Add(new ProcessData(
					    proc.ProcessName,
					    proc.PagedMemorySize64,
					    proc.StartTime.ToString(),
					    proc.BasePriority,
					    proc.Threads.Count));
				}
				catch (Exception ex)
				{
                    if(FailedToGetProcess != null)
                        FailedToGetProcess(this, new ProcessEventArgs(ex.Message,proc.ProcessName));
				}
			}
			return processData.ToArray();
		}

        public event EventHandler<ProcessEventArgs> KillFail;
        public event EventHandler<ProcessEventArgs> KillSuccess;
        public bool KillProcess(string processName)
        {
            try
            {
                Process[] processes = Process.GetProcessesByName(processName);
                foreach (Process proc in processes)
                {
                    proc.Kill();
                }
                if(KillSuccess != null)
                    KillSuccess(this, new ProcessEventArgs("Процес завершено", processName));
                return true;
            }
            catch(Exception ex)
            {
                if(KillFail != null)
                    KillFail(this, new ProcessEventArgs(ex.Message,processName));
                return false;
            }
        }

        public event EventHandler<ProcessEventArgs> StartFail;
        public event EventHandler<ProcessEventArgs> StartSuccess;
        public bool StartProcess(string processName)
        {
            try
            {
                Process.Start(processName);
                if (StartSuccess != null)
                    StartSuccess(this, new ProcessEventArgs("Процес запущено", processName));
                return true;
            }
            catch (Exception ex)
            {
                if (StartFail != null)
                    StartFail(this, new ProcessEventArgs(ex.Message, processName));
                return false;
            }
        }

        public event EventHandler<ProcessEventArgs> PriorityChangeSuccess;
        public event EventHandler<ProcessEventArgs> InvalidPriority;
        public event EventHandler<ProcessEventArgs> PriorityChangeFail;
        public bool ChangeProcessPriority(string processName, int newPriority)
        {
            if (prioDict.ContainsKey(newPriority)) {
                Process[] processes = Process.GetProcessesByName(processName);
                foreach (Process proc in processes)
                {
                    try
                    {
                        proc.PriorityClass = prioDict[newPriority];
                    }
                    catch(Exception ex)
                    {
                        if (PriorityChangeFail != null)
                            PriorityChangeFail(this, new ProcessEventArgs(ex.Message, processName));
                        return false;
                    }
                }
                if (PriorityChangeSuccess != null)
                    PriorityChangeSuccess(this, new ProcessEventArgs("Пріорітет змінено успішно", processName));
                return true;
            }
            else
            {
                if (InvalidPriority != null)
                    InvalidPriority(this, new ProcessEventArgs("Недійсний пріоритет", processName));
                return false;
            }
        }
    }
}
