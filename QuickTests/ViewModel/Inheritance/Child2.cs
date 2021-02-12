using System.Collections.Generic;

namespace QuickTests.ViewModel.Inheritance
{
    class Child2 : BaseClass
    {

        public IList<int> ProperyList
        {
            get
            {
                if (_fieldList == null)
                    _fieldList = new List<int>(2);
                return _fieldList;
            }
        }
        protected IList<int> _fieldList;

        public Child2()
        {
            a = 2;
        }

        public override void WriteItself()
        {
            a = 22;
            App.mw.Inheritance.ConsoleInnerText += $"I am in Child2 and this is the value changed of class2: {a} \n";
        }

        public void MetdohOnlyInclass2()
        {
            App.mw.Inheritance.ConsoleInnerText += "Here I am Child2 in method \"MetdohOnlyInClass2\"\n";
        }
        
    }
}
