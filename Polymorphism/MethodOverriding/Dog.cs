using System;
namespace MethodOverriding
{
    public class Dog:Animal
    {
        public override void Display()
        {
            Console.WriteLine("Method of dog class called");
        }
    }
}