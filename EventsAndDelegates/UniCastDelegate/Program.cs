using System;

namespace UniCastDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            //Unicaste delegate
            NumberChanger nc1 = new NumberChanger(TestDelegate.AddNum);
            NumberChanger nc2 = new NumberChanger(TestDelegate.MultNum);

            nc1(25);
            Console.WriteLine($"Value of Num: {TestDelegate.getNum()}");
            nc2(5);
            Console.WriteLine($"Value of Num: {TestDelegate.getNum()}");

            //Multicasting Delegate
            NumberChanger nc;
            NumberChanger nc3 = new NumberChanger(TestDelegate.AddNum);
            NumberChanger nc4 = new NumberChanger(TestDelegate.MultNum);

            nc = nc3;
            nc = nc+nc4;
            nc(5);
            Console.WriteLine($"Value of Num :{TestDelegate.getNum()}");
            Console.ReadKey();

        }
    }

}
   
