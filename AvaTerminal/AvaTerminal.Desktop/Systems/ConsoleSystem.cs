using Avalonia.Controls.Shapes;
using Avalonia.Terminal.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Avalonia.Terminal.Systems
{
    public class ConsoleSystem
    {
        public bool IsRunning { get; private set; }
        private static Lazy<ConsoleSystem> _instance = new Lazy<ConsoleSystem>(() => new ConsoleSystem());
        public static ConsoleSystem Instance => _instance.Value;
        public Action<string>? OnDataReceived;

        private Process? _currentProcess;

        private void Start(string tool = "cmd.exe")
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = tool,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                StandardOutputEncoding = Encoding.UTF8
            };
            _currentProcess = new Process { StartInfo = startInfo };
            _currentProcess.OutputDataReceived += (s, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                    OnDataReceived?.Invoke(e.Data);
            };

            _currentProcess.ErrorDataReceived += (s, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                    OnDataReceived?.Invoke("ERROR: " + e.Data);
            };

            _currentProcess.Start();
            _currentProcess.BeginOutputReadLine();
            _currentProcess.BeginErrorReadLine();
        }

        public void Stop()
        {
            _currentProcess?.Close();
            
        }

        public void Execute(string command)
        {
            if (_currentProcess is null) Start();
            _currentProcess.StandardInput.WriteLine(command);
        }

        public void Switch(string tool)
        {
            Stop();
            Start(tool);
        }
    }
}
