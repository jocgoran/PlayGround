﻿using QuickTests.ViewModel.Inheritance;
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
            BaseClass class1 = new Child1();
            BaseClass class2 = new Child2();
            ConsoleInnerText += $"Value of class1 after initialization {class1.a} \n";
            ConsoleInnerText += $"Value of class2 after initialization {class2.a} \n";
            class1.WriteItself();
            class2.WriteItself();
            OnPropertyChanged("ConsoleInnerText");
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}