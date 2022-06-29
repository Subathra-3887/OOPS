using System;

namespace FunctionDelegates
{
    class Program
    {
        static double Sum(int a, int b)
        {
            return a+b;
        }
        static double Subract(int a ,int b)
        {
            return a-b;
        }
        static double Multiply(int a, int b)
        {
            return a*b;
        }
        static double Divide(int a , int b)
        {
            return (double)a/b;
        }
        static double Calculate(Func<int, int, double> operation, int x, int y)
        {
            return operation(x,y);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Calculate(Divide,10,20));
            Console.WriteLine(Calculate(Sum,10,20));
        }
    }

}
   
