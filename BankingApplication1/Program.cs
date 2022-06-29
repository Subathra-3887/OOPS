using System;
using System.Collections.Generic;

namespace BankingApplication
{
    class Program
    {
        static List<CustomerDetails> customerList = new List<CustomerDetails>();
        static CustomerDetails currentUser=null;
        public static void Main(string[] args)
        {
            Default();
            int option;
            do
            {
                Console.WriteLine("Menu: \n1.Registration \n2.Login \n3.Exit");
                option = int.Parse(Console.ReadLine());
                switch(option)
                {
                    case 1:
                    {
                        Registration();
                        break;
                    }
                    case 2:
                    {
                        Login();
                        break;
                    }

                }   
            }while(option!=3);
                
        }
    public static void Registration()
    {
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
    }
static void Default()
{
    CustomerDetails customer=new CustomerDetails("Suba","Kaliamoorthy",new DateTime(17/02/1999),Gender.Female,9876543212,"suba@gmail.com",10000,Account.Savings); 
    customerList.Add(customer);
}
    public static void Login()
    {
        Console.WriteLine("Enter your Account Number:");
        string accountNumber = Console.ReadLine().ToUpper();

        foreach(CustomerDetails customer in customerList)
        {   
            if(accountNumber == customer.AccountNumber)
            {
            Console.WriteLine("Login successfull");
            currentUser= customer;
            SubMenu();
            }
        }
    }
    static void SubMenu()
    {
        int option;
            do
            {
                Console.WriteLine("SubMenu: \n1.Deposit \n2.Withdraw \n3.Balance Check \n4.Exit");
                option = int.Parse(Console.ReadLine());
                switch(option)
                {
                    case 1:
                    {
                        currentUser.Deposit();
                        break;
                    }
                    case 2:
                    {
                        currentUser.Withdraw();
                        break;
                    }
                    case 3:
                    {
                        currentUser.BalanceCheck();
                        break;
                    }

                }   
            }while(option!=4);

    }
    }

}
   
