using System.Linq;
using System.Windows;

namespace QuickTests.ViewModel.Inheritance
{
    class BaseClass
    {

        public int a = 0;
        protected int b = 0;

        public BaseClass()
        {
            a = 999;
        }

        public virtual void WriteItself()
        {
            App.mw.Inheritance.ConsoleInnerText += $"This is the value from BaseClass {a} \n";
        }

    }
}
