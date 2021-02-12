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
            App.mw.Inheritance.ConsoleInnerText += $"I am BaseClass and this is the value a from BaseClass {a} \n";
        }

    }
}
