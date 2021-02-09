using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core
{
    public class SystemInformation
    {
        public Dictionary<string,string> Info()
        {
            Dictionary<string, string> informations = new Dictionary<string, string>() {
                {"user",Environment.UserName },
                {"directory",Environment.CommandLine },
                {"time",DateTime.Now.ToString() },
                {"short_time",DateTime.Now.ToShortTimeString() },
                {"cpu_Count",Environment.ProcessorCount.ToString() },
                {"os_version",Environment.OSVersion.ToString() }
            };
            return informations;
        }

        public List<string> SystemProcess()
        {
            List<string> ProcessList = new List<string>();
            foreach (var item in Process.GetProcesses())
            {
                ProcessList.Add($"ID :{item.Id} | Name :{item.ProcessName}");
            }
            return ProcessList;
        }

        public string Command(string cmd)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd");
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.UseShellExecute = false;
            processStartInfo.CreateNoWindow = false;
            Process ps = Process.Start(processStartInfo);
            ps.StandardInput.WriteLine(cmd);
            ps.StandardInput.WriteLine(@"exit");
            return ps.StandardOutput.ReadToEnd();
        }
    }
}
