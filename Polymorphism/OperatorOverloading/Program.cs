using System;

namespace OperatorOverloading
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Box box1 = new Box(10,10,10);
            box1.CalculateVolume();
            Box box2 = new Box(20,20,20);
            box2.CalculateVolume();
            Box box3 = box1 + box2;
            box3.CalculateVolume();
        }
    }

}
   
