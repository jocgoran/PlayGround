using System.Diagnostics;
using System.Linq;
using System.Windows.Controls;

namespace ProcessReflection.View
{
    /// <summary>
    /// Interaction logic for HookProcess.xaml
    /// </summary>
    public partial class HookProcess : UserControl
    {
        public HookProcess()
        {
            InitializeComponent();
        }

        public void ListProcesses(object sender, System.Windows.RoutedEventArgs e)
        {
            // clear the text box
            App.mw.HookProcess.ProcessesList.Clear();

            // add all info about processes
            Process.GetProcesses().ToList().ForEach(p =>
              {
                  App.mw.HookProcess.ProcessesList.Text += $"[{p.Id}] {p.ProcessName} ({p.Threads.Count})\n";
              });
        }
    }
}
