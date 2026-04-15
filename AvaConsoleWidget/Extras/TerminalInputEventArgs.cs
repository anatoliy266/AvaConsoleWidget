using Avalonia.Input;
using Avalonia.Interactivity;

namespace Avalonia.Terminal.Extras
{
    internal class TerminalInputEventArgs: RoutedEventArgs
    {
        public string Text { get; }

        public TerminalInputEventArgs(RoutedEvent routedEvent, string input): base(routedEvent)
        {
            Text = input;
        }
    }
}