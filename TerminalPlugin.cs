using Microsoft.SemanticKernel;
using System.ComponentModel;
using System.Diagnostics;

namespace TerminalAgent
{
    public class TerminalPlugin
    {
        [KernelFunction("run_command")]
        [Description("Execute windows terminal commands via ProcessStartInfo in dotnet")]
        [return: Description("Output of terminal")]
        public string RunCommand(string command, string arguments, string workingDirectory)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = command,
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            if (!string.IsNullOrEmpty(workingDirectory))
            {
                processStartInfo.WorkingDirectory = workingDirectory;
            }

            using (Process process = new Process())
            {
                process.StartInfo = processStartInfo;
                process.Start();

                // Read the output
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                process.WaitForExit();

                // Print the output to the console
                return output;

                // Print errors if any
                if (!string.IsNullOrEmpty(error))
                {
                    return ("Error: " + error);
                }
            }
        }
    }
}
