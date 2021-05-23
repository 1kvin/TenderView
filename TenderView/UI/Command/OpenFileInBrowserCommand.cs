using System;
using System.Diagnostics;
using System.Windows.Input;

namespace TenderView.UI.Command
{
    public class OpenFileInBrowserCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Process.Start(new ProcessStartInfo("cmd", $"/c start {parameter}") { CreateNoWindow = true });
        }

        public event EventHandler CanExecuteChanged;
    }
}