using QuickTests.ViewModel.Inheritance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace QuickTests.View
{
    /// <summary>
    /// Interaktionslogik für Inheritance.xaml
    /// </summary>
    public partial class Inheritance : UserControl, INotifyPropertyChanged
    {
        public string ConsoleInnerText { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public Inheritance()
        {
            InitializeComponent();
            OutputConsole.DataContext = this;
        }

        private void InitChilds(object sender, RoutedEventArgs e)
        {
            Child1 class1 = new Child1();
            Child2 class2 = new Child2();
            ConsoleInnerText += $"Value of class1 after initialization {class1.a} \n";
            ConsoleInnerText += $"Value of class2 after initialization {class2.a} \n";
            
            // child variables override
            class1.WriteItself();
            class2.WriteItself();

            // Liskov don't work if class1 != class2
            ConsoleInnerText += "\n";
            ConsoleInnerText += "To call a method in Child2 I can's substitute the the instance to upper cast\n";
            class2.MetdohOnlyInclass2();

            // Create base class and DownCast
            ConsoleInnerText += "Intantiate a BaseClass and try to access the child\n";
            BaseClass baseClass = new BaseClass();
            // SuperDuper
            Child1 superDuperChild1 = baseClass as Child1;
            

            ConsoleInnerText += "1.  By Property\n";
            try
            {
                IList<int> myVar = superDuperChild1.ProperyList;
                // not executed
                ConsoleInnerText += $"Property ProperyList of class1 after casting is {string.Join(",", myVar)} \n";
            }
            catch (Exception ex)
            {
                ConsoleInnerText += $"{ex.Message} \n";
            }

            // SuperDuper
            ConsoleInnerText += "1.  By field\n";
            try
            {
                IList<int> myVar = superDuperChild1._fieldList;
                // not executed
                ConsoleInnerText += $"field _fieldList of class1 after casting is {string.Join(",", myVar)} \n";
            }
            catch (Exception ex)
            {
                ConsoleInnerText += $"{ex.Message} \n";
            }

            // example of up and down casting
            BaseClass classAsBase = new Child1();
            Child1 superDooperCasting = classAsBase as Child1;
            string myNewString = superDooperCasting.myString;
            ConsoleInnerText += $"Value up and down casting {myNewString} \n";

            OnPropertyChanged("ConsoleInnerText");
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
