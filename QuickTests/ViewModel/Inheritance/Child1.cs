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
        public IList<int> ProperyList
        {
            get
            {
                if (_fieldList == null)
                    _fieldList = new List<int>(1);
                return _fieldList;
            }
        }
        public IList<int> _fieldList;
        public string myString = "abc";

        public Child1()
        {
            a = 1;
        }

        public override void WriteItself()
        {
            a = 11;
            App.mw.Inheritance.ConsoleInnerText += $"I am Child1 class and this is the value changed of class1 {a} \n";
            App.mw.Inheritance.ConsoleInnerText += $"I am Child1 class and his is the value of baseClass {base.a} \n";
        }

    }
}
