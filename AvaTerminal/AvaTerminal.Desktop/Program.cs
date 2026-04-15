using Avalonia;
using System;
using System.Threading.Tasks;

namespace AvaTerminal.Desktop
{
    internal sealed class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .WithInterFont()
                .LogToTrace();


        //private async Task LoadToolsAsync()
        //{
        //    var found = await Task.Run(() => _popularTools
        //        .Select(x => ShellHelper.RunCommand("cmd.exe", $"where {x}.exe").Trim())
        //        .Where(path => !string.IsNullOrWhiteSpace(path))
        //        .Select(Path.GetFileName)
        //        .ToList());

        //    await Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() =>
        //    {
        //        Tools.Clear();
        //        foreach (var tool in found) Tools.Add(tool!);
        //    });
        //}
    }
}
