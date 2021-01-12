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

        public MultiThreading()
        {
            Thread t1 = new Thread(Method1); 
            Thread t2 = new Thread(Method2);
            t1.Name = "Thread Nro 1";
            t2.Name = "Thread Nro 2";
            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
        }

        private void Method1()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
                App.mw.CrossThreadingVarAccess.ConsoleInnerText1 += $"Thread {Thread.CurrentThread.Name} interaction Nro {i}\n";
                App.mw.CrossThreadingVarAccess.ConsoleInnerText3 += $"Thread {Thread.CurrentThread.Name} interaction Nro {i}\n";
            }
        }

        private void Method2()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
                App.mw.CrossThreadingVarAccess.ConsoleInnerText2 += $"Thread {Thread.CurrentThread.Name} interaction Nro {i}\n";
                App.mw.CrossThreadingVarAccess.ConsoleInnerText3 += $"Thread {Thread.CurrentThread.Name} interaction Nro {i}\n";
            }
        }
    }
}
