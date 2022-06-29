using System;
namespace UniCastDelegate
{
    delegate int NumberChanger(int n); //Can add methods have int retun types and 1 int argument
    class TestDelegate
    {
        static int num = 100;
        public static  int AddNum(int p)
        {
            num = num+p;
            return num;
        }
        public static int MultNum(int q)
        {
            num = num*q;
            return num;
        }    
        public static int getNum()
        {
            return num;
        }
    }
}