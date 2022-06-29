using System;


namespace OopsPractise
{
    class Program
    {
        static void Main(string[] args)
        {
            Base baseObject = new Base();
            //Console.WriteLine(baseObject._variable);
            baseObject.DisplayPrivate();
           // Console.WriteLine(baseObject._variable);
            Console.WriteLine(baseObject.Variable);
            //Console.WriteLine(baseObject.Value);
            OutsideDerived obj2 = new OutsideDerived(); 
            Console.WriteLine(obj2.Value);
        }
        
    }

}
   
