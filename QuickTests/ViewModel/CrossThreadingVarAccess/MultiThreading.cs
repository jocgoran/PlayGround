using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuickTests.ViewModel.CrossThreadingVarAccess
{
    class MultiThreading
    {
        public string InstanceVarOfMainThread = "Initialized in MainThread";

        public MultiThreading()
        {
            string LocalMainThread = "Local variable, set in function of main thread";

            App.mw.CrossThreadingVarAccess.ConsoleInnerText3 += $"In Thread {Thread.CurrentThread.Name}, BEFORE Thread.Start(): InstanceVarOfMainThread={InstanceVarOfMainThread}\n";

            Thread t1 = new Thread(Method1); 
            Thread t2 = new Thread(Method2);
            t1.Name = "Thread Nro 1";
            t2.Name = "Thread Nro 2";
            t1.Start();
            t2.Start();

            App.mw.CrossThreadingVarAccess.ConsoleInnerText3 += $"In Thread {Thread.CurrentThread.Name}, AFTER Thread.Start(): InstanceVarOfMainThread={InstanceVarOfMainThread}\n";

            //t1.Join();
            t2.Join();

            App.mw.CrossThreadingVarAccess.ConsoleInnerText3 += $"In Thread {Thread.CurrentThread.Name}, AFTER Thread.Join(): InstanceVarOfMainThread={InstanceVarOfMainThread}\n";
        }

        private void Method1()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
                App.mw.CrossThreadingVarAccess.ConsoleInnerText1 += $"Thread {Thread.CurrentThread.Name} interaction Nro {i}\n";
                App.mw.CrossThreadingVarAccess.ConsoleInnerText3 += $"Thread {Thread.CurrentThread.Name} interaction Nro {i}\n";
            }

            InstanceVarOfMainThread = $"Modified by {Thread.CurrentThread.Name}";
            App.mw.CrossThreadingVarAccess.ConsoleInnerText3 += $"In Thread {Thread.CurrentThread.Name}, TERMINATED ELABORATION: InstanceVarOfMainThread={InstanceVarOfMainThread}\n";
        }

        private void Method2()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
                App.mw.CrossThreadingVarAccess.ConsoleInnerText2 += $"Thread {Thread.CurrentThread.Name} interaction Nro {i}\n";
                App.mw.CrossThreadingVarAccess.ConsoleInnerText3 += $"Thread {Thread.CurrentThread.Name} interaction Nro {i}\n";
            }

            InstanceVarOfMainThread = $"Modified by {Thread.CurrentThread.Name}";
            App.mw.CrossThreadingVarAccess.ConsoleInnerText3 += $"In Thread {Thread.CurrentThread.Name}, TERMINATED ELABORATION: InstanceVarOfMainThread={InstanceVarOfMainThread}\n";
        }
    }
}
