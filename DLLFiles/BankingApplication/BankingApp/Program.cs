using System;
using System.Collections.Generic;
using BankingLibrary;
namespace BankingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string condition = "";
            List<CustomerDetails> customerList = new List<CustomerDetails>();

            do{
            Console.WriteLine("Enter your name:");
            string name =Console.ReadLine(); 
            Console.WriteLine("Enter your Father's Name:");
            string fatherName = Console.ReadLine();
            Console.WriteLine("Enter your DOB :");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            Console.WriteLine("Enter your gender:");
            int genderValue = int.Parse(Console.ReadLine());
            Gender gender = Gender.Default;
            while(!(genderValue>0&&genderValue<4))
            {
                Console.WriteLine("Enter your gender:");
                genderValue = int.Parse(Console.ReadLine());
            }
            gender = (Gender)genderValue;
            Console.WriteLine("Enter your mobile number:");
            long mobileNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter your email Id:");
            string emailId = Console.ReadLine();
            Console.WriteLine("Enter your balance:");
            double balance = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter your account type:");
            int accountValue = int.Parse(Console.ReadLine());
            Account accountType = Account.Default;
            while(!(accountValue>0 && accountValue<4))
            {
                Console.WriteLine("Enter your account type:");
                accountValue = int.Parse(Console.ReadLine());
            }
            accountType = (Account)accountValue;
            CustomerDetails customer = new CustomerDetails(name,fatherName,dob,gender,mobileNumber,emailId,balance,accountType);
            Console.WriteLine($"Account Number:{customer.AccountNumber}");
            customerList.Add(customer);

            Console.WriteLine("Do you want to continue?(Yes/No)");
            condition=Console.ReadLine().ToLower();

            }while(condition=="yes");
            
            Console.WriteLine("Enter your Account Number:");
            string accountNumber = Console.ReadLine().ToUpper();

            foreach(CustomerDetails customer in customerList)
            {   
                if(accountNumber == customer.AccountNumber)
                {
                customer.BalanceCheck();
                customer.Deposit();
                customer.Withdraw();
                }
            }
        }
    }

}
   
