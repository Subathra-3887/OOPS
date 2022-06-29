using System;
namespace OopsPractise
{
    public class Derived:Base
    {
        public void DisplayProtected()
        {
            Derived derivedObject = new Derived();
             Console.WriteLine(derivedObject.Value);
        }
        public void DisplayInternal()
        {
            Derived derivedObject = new Derived();
            Console.WriteLine(_value);
        }
        
    }
}