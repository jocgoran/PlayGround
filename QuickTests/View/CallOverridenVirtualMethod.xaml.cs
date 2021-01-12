using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using QuickTests.ViewModel.CallOverridenVirtualMethod;

namespace QuickTests.View
{
    /// <summary>
    /// Interaktionslogik für CallOverridenVirtualMethod.xaml
    /// </summary>
    public partial class CallOverridenVirtualMethod : UserControl, INotifyPropertyChanged
    {
        public string ConsoleInnerText { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public CallOverridenVirtualMethod()
        {
            InitializeComponent();
            OutputConsole.DataContext = this;
        }

        private void InterlaceMethods(object sender, RoutedEventArgs e)
        {
            Child child = new Child();
            child.WriteSomething();
            OnPropertyChanged("ConsoleInnerText");
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
