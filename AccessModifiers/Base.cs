using System;
namespace OopsPractise
{
    public class Base
    {
        private  int _varialble = 100;
        public int Variable = 200; 
        protected int Value = 300;
        internal int _value = 400;
        public void DisplayPrivate()
        {
            Console.WriteLine(_varialble);
        }
       
    }
}