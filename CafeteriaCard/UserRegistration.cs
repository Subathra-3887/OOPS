using System;

namespace CafeteriaCard
{
    public class UserRegistration
    {
        public static int s_userId = 1000;
        public string UserId { get; }
        public string UserName { get; set; }
        public long MobileNumber { get; set; }
        public string WorkStation { get; set; }
        public double Balance { get; set; }
        
        public UserRegistration(string userName,long mobileNumber,string workStation,double balance)
        {
            s_userId++;
            UserId = "SF"+s_userId;
            UserName=userName;
            MobileNumber=mobileNumber;
            WorkStation=workStation;
            Balance=balance;
        }
        public void Recharge()
        {
            Console.WriteLine("Enter the amount to be recharged:");
            double recharge = double.Parse(Console.ReadLine());
            Balance = Balance+recharge;
            Console.WriteLine($"Total Balance: {Balance}");
        }
        
    }
}