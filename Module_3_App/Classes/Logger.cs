using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3_App.Classes
{
    public class Logger
    { 

        List<string> logs = new List<string>();
        public delegate void LimitHandler(List<string> logs);
        public event LimitHandler? Notify;
        private void PrintLog()
        {
            Thread.Sleep(1000);
            this.logs.Add(new string(DateTime.Now.ToString() + ' ' + logs.Count.ToString()));
        }

        public async Task PrintAsync()
        {
            while(logs.Count < 50)
            {
                if (logs.Count > 50)
                {
                    return;
                }
                await Task.Run(() => PrintLog());
                Console.WriteLine(logs[logs.Count - 1]);
                Notify?.Invoke(logs);
            }
        }

        public async Task PrintAsyncSecond()
        {
            while (logs.Count < 100)
            {
                if (logs.Count > 100)
                {
                    return;
                }
                await Task.Run(() => PrintLog());
                Console.WriteLine(logs[logs.Count - 1]);
                Notify?.Invoke(logs);
            }
        }
    }
}
