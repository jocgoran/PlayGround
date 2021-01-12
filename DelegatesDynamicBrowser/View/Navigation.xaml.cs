using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Model = DelegatesDynamicBrowser.Model;

namespace DelegatesDynamicBrowser.View
{
    /// <summary>
    /// Interaction logic for Navigation.xaml
    /// </summary>
    public partial class Navigation : UserControl
    {

        public Navigation()
        {
            InitializeComponent();
        }

        private void browse_for_dependencies(object sender, RoutedEventArgs e)
        {

            Model.DllConnector.Connect();
        }
    }
}
