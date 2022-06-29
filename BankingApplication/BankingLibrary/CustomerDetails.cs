using System;

namespace BankingLibrary
{
    public enum Gender{Default,Male,Female,Others};
    public enum Account{Default,Savings,RD,Current};
    public class CustomerDetails
    {   
        private static int s_accountNumber = 10000;
        public string AccountNumber { get; set;}
        public string CustomerName { get; set; } //Auto Property
        public string FatherName { get; set; }
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        public long MobileNumber { get; set; }
        public string EmailId { get; set; }
        public double Balance { get; set; }
        public Account AccountType { get; set; }

        public CustomerDetails(string name,string fatherName,DateTime dob,Gender gender,long mobileNumber, string emailId,double balance,Account accountType)
        {
            s_accountNumber++;
            AccountNumber = "HDFC"+s_accountNumber;
            CustomerName=name;
            FatherName=fatherName;
            DOB=dob;
            Gender=gender;
            MobileNumber=mobileNumber;
            EmailId=emailId;
            Balance=balance;
            AccountType=accountType;
        }   
        public void BalanceCheck()
        {
            Console.WriteLine($"The amount of money in your account is: {Balance}");
        }
        public void Deposit()
        {
            Console.WriteLine("Enter the amount to be deposited:");
            double depositMoney = double.Parse(Console.ReadLine());
            if(depositMoney>0)
            {
            Balance = Balance+depositMoney;
            Console.WriteLine($"Updated money in your account: {Balance}");
            }
            else
            {
                Console.WriteLine("Invalid amount! Please enter the correct amount.");
            }
        }
        public void Withdraw()
        {   
            Console.WriteLine("Enter the amount to be withdrawn:");
            double moneyWithdrawn = double.Parse(Console.ReadLine());
            if(moneyWithdrawn<Balance)
            {
            Balance = Balance-moneyWithdrawn;
            Console.WriteLine($"The amount of money in your account after withdrawal: {Balance}");
            }
            else
            {
                Console.WriteLine("Insufficient Balance! Enter the correct amount");
            }

        }
    }
}