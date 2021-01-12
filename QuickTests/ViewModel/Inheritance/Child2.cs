namespace QuickTests.ViewModel.Inheritance
{
    class Child2 : BaseClass
    {

        public Child2()
        {
            a = 2;
        }

        public override void WriteItself()
        {
            a = 22;
            App.mw.Inheritance.ConsoleInnerText += $"This is the value changed of class2: {a} \n";
        }
    }
}
