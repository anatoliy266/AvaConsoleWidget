using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Avalonia.Terminal.Helpers
{
    public static class ShellHelper
    {
        public static string RunCommand(string filename, string command)
        {
            var psi = new ProcessStartInfo()
            {
                FileName = filename,
                Arguments = $"/c {command}", 
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = Process.Start(psi);
            if (process == null) return string.Empty;

            string output = process.StandardOutput.ReadToEnd().Trim();
            process.WaitForExit();

            return output;
        }
    }
}
