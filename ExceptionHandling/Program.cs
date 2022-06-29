using System;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
            Console.WriteLine("Enter number 1:");
            int number1 =int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number 2:");
            int number2 = int.Parse(Console.ReadLine());
            int result = number1/number2;
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Enter number 1:");
                int number1 =int.Parse(Console.ReadLine());
                Console.WriteLine("Enter number 2:");
                int number2 = int.Parse(Console.ReadLine());
                int result = number1/number2;
            }
        }
    }

}
   
