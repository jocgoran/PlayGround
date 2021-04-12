using System;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Linq;

namespace QuickTests.View
{
    /// <summary>
    /// Interaktionslogik für ConvertToXPath.xaml
    /// </summary>
    public partial class ConvertToXPath : UserControl
    {
        public ConvertToXPath()
        {
            InitializeComponent();
        }

        private void OpenFileDialog(object sender, System.Windows.RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.Title = "Add the XML file...";
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML files (*.xml)|*.xml";

            // Explore open to local directory
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); ;

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                OpenFileDlg.Text = filename;

                // Show content into RichTextBlock
                XElement xml = XElement.Load(filename);
                XMLContent.Text = xml.ToString();
            }
        }

        private void WalkThroughXML(object sender, System.Windows.RoutedEventArgs e)
        {
            // read the XML string 
            string sXml = XMLContent.Text;

            // check preconditions
            if (string.IsNullOrEmpty(sXml)) return;

            // parse the XML string
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(sXml);

            // trasversal interation through all XML
            string XPath = "/";
            WalkIntoNode(xml, XPath);
        }

        private void WalkIntoNode(XmlNode node, string XPath)
        {

            if (string.Equals($"{node.NodeType}", "Element", StringComparison.OrdinalIgnoreCase))
            {
                // concatenate node
                XPath += $"{node.Name}/";
            }
            else if (string.Equals($"{node.NodeType}", "Text", StringComparison.OrdinalIgnoreCase))
            {
                // concatenate node value
                XPath += $"{node.Value}\n";
                XPathFormatted.Text += XPath;
            }
            // go deeper into child
            foreach (XmlNode child in node.ChildNodes)
            {
                // go futher to next child
                WalkIntoNode(child, XPath);
            }
        }
    }
}
