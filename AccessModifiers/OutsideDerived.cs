using System;
namespace OopsPractise
{
    public class OutsideDerived:Outside.PInternal
    {
        public void DisplayOutside()
        {
            Console.WriteLine(Value);
        }
    }
}