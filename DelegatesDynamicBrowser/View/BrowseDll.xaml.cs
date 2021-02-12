using System;
using System.Windows;
using System.Windows.Controls;

namespace ProcessReflection.View
{
    /// <summary>
    /// Interaction logic for BrowseDll.xaml
    /// </summary>
    public partial class BrowseDll : UserControl
    {
        public BrowseDll()
        {
            InitializeComponent();
        }

        private void OpenFileDialog(object sender, System.Windows.RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.Title = "Add a Dynamic Linked Library ...";
            dlg.DefaultExt = ".dll";
            dlg.Filter = "Dynamic Linked Libraries|*.dll";

            // Explore open to local directory
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86); ;

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                OpenFileDlg.Text = filename;
            }
        }

        private void BrowseForDependencies(object sender, RoutedEventArgs e)
        {
            Model.DllConnector.Connect(OpenFileDlg.Text);
        }
    }


}
