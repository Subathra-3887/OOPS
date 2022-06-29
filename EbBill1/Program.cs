using System;
using System.Collections.Generic;

namespace EbBill
{
class Program
{
    static List<BillDetails> customerList = new List<BillDetails>();
    static BillDetails currentUser = null;
    public static void Main(string[] args)
    {
        Default();
        int option;
        do
        {    
            Console.WriteLine();
            Console.WriteLine("Select Main Menu");
            Console.WriteLine("1.Registration \n2.Login \n3.Exit");
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
                case 3:
                {
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
        Console.WriteLine("Enter your mobile number:");
        long mobileNumber = long.Parse(Console.ReadLine());
        Console.WriteLine("Enter your email Id:");
        string emailId = Console.ReadLine();
        
        BillDetails customer = new BillDetails(name,fatherName,mobileNumber,emailId);
        Console.WriteLine($"Meter Id:{customer.MeterId}");

        customerList.Add(customer);
    }
    static void Default()
    {
        BillDetails student = new BillDetails ("Suba","Kaliamoorthy",9876543212,"suba@gmail.com");
        customerList.Add(student);
    }
    public static void Login()
    {
        Console.WriteLine("Enter your Meter ID:");
        string meterId  = Console.ReadLine().ToUpper();
        foreach(BillDetails customer in customerList)
        {
            if(meterId == customer.MeterId)
            {
                Console.WriteLine("Login Succesfull");
                currentUser =customer;
                SubMenu();
            }
            else
            {
                Console.WriteLine("Invalid User ID");
            }
        }
    }
    public static void SubMenu()
    {
        int option;
        do
        {   
            Console.WriteLine();
            Console.WriteLine("Select Sub Menu:\n1.Display Details \n2.Calculate Bill Amount \n3.Exit");
            option = int.Parse(Console.ReadLine());
            switch(option)
            {
                case 1:
                {   
                    currentUser.Display();
                    break;
                }
                case 2:
                {
                    currentUser.CalculateBill();
                    break;
                }
                
            }
        }while(option!=3);
        Console.WriteLine();
    }

}
}


   
