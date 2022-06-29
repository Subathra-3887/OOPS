using System;

namespace MethodOverloading
{
    class Program
    {
        static void Display(int a)
        {
            Console.WriteLine($"Argument: {a}");
        }
        static void Display(string name)
        {
            Console.WriteLine($"Argument: {name}");
        }
        static void Display(int a,int b)
        {
            Console.WriteLine($"Arguments: {a} and {b}");
        }
        static void Main(string[] args)
        {
           Display(100);
           Display(100,200);
           Display("Suba");
        }
    }

}
   
