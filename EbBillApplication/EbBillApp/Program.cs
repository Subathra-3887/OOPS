using System;
using System.Collections.Generic;
using EbBillLibrary;
namespace EbBillApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string condition = "";
            List<BillDetails> customerList = new List<BillDetails>();

            do{
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

            Console.WriteLine("Do you want to continue?(Yes/No)");
            condition=Console.ReadLine().ToLower();

            }while(condition=="yes");
            
            Console.WriteLine("Enter your Meter ID:");
            string meterId  = Console.ReadLine().ToUpper();
            foreach(BillDetails customer in customerList)
            {
                if(meterId == customer.MeterId)
                {
                customer.Display();
                double unitsUsed = customer.RegisterNoOfUnits();
                customer.CalculateBill(unitsUsed);
                }
            }
        }
    }

}
   
