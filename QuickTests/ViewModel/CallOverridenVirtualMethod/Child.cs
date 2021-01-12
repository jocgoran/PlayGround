using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace QuickTests.ViewModel.CallOverridenVirtualMethod
{
    class Child : BaseClass
    {
        public Child()
        {
        }

        public override void WriteSomething()
        {
            App.mw.CallOverridenVirtualMethod.ConsoleInnerText += $"This is the execution from mehof from the child class\n";
            base.WriteSomething();
        }

    }
}
