using QuickTests.ViewModel.CrossThreadingVarAccess;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace QuickTests.View
{
    /// <summary>
    /// Interaktionslogik für CrossThreadingVarAccess.xaml
    /// </summary>
    public partial class CrossThreadingVarAccess : UserControl, INotifyPropertyChanged
    {
        public string ConsoleInnerText1 { get; set; }
        public string ConsoleInnerText2 { get; set; }
        public string ConsoleInnerText3 { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public CrossThreadingVarAccess()
        {
            InitializeComponent();
            OutputConsole1.DataContext = this;
            OutputConsole2.DataContext = this;
            OutputConsole3.DataContext = this;
        }

        private void BuildThreads(object sender, RoutedEventArgs e)
        {
            MultiThreading MultiThreadingSampleClass = new MultiThreading();
            OnPropertyChanged("ConsoleInnerText1");
            OnPropertyChanged("ConsoleInnerText2");
            OnPropertyChanged("ConsoleInnerText3");
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
