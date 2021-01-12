using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace QuickTests.ViewModel.Inheritance
{
    class Child1 : BaseClass
    {
        public Child1()
        {
            a = 1;
        }

        public override void WriteItself()
        {
            a = 11;
            App.mw.Inheritance.ConsoleInnerText += $"This is the value changed of class1 {a} \n";
            App.mw.Inheritance.ConsoleInnerText += $"This is the value of baseClass {base.a} \n";
        }

    }
}
