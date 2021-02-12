using System.Windows;

namespace ProcessReflection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            App.mw = this;
        }

        private void BrowseDll_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
