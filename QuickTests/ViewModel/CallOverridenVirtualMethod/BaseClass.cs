using System.Linq;
using System.Windows;

namespace QuickTests.ViewModel.CallOverridenVirtualMethod
{
    class BaseClass
    {

        public BaseClass()
        {
        }

        public virtual void WriteSomething()
        {
            App.mw.CallOverridenVirtualMethod.ConsoleInnerText += $"This is the execution of the method form base class.\n";
        }

    }
}
