using System.Diagnostics;

namespace ProcessKillerUtility
{
    public class ProcessKiller
    {
        public void Kill(string[] args)
        {
            string processToKill = args[0];
            double duration = double.Parse(args[1]);
            double frequency = double.Parse(args[2]);

            KillProcess(processToKill, duration);

            System.Timers.Timer timer = new System.Timers.Timer(frequency * 60 * 1000);
            timer.Elapsed += (sender, e) => OnTimedEvent(sender, e, processToKill, duration);
            timer.AutoReset = true;
            timer.Enabled = true;

            Console.ReadLine();

            timer.Stop();
            timer.Dispose();
        }       

        private void OnTimedEvent(object? sender, System.Timers.ElapsedEventArgs e, String processToKill, double duration)
        {
            KillProcess(processToKill, duration);
        }

        private void KillProcess(String processToKill, double duration)
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                if (process.ProcessName == processToKill)
                {
                    TimeSpan processDuration = DateTime.Now - process.StartTime;

                    if (processDuration.TotalMinutes > duration)
                    {
                        process.Kill();
                        using (StreamWriter writer = File.AppendText("log.txt"))
                        {
                            writer.WriteLine($"Process {process.ProcessName} with duration {processDuration.TotalMinutes} minutes killed at {DateTime.Now.ToString()}");
                        }
                    }
                }
            }
        }

    }

   

}
