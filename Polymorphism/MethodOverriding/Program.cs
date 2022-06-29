using System;

namespace MethodOverriding
{

    class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Animal();
            Dog labrador = new Dog();
            animal.Display();
            labrador.Display();
        }
    }

}
   
