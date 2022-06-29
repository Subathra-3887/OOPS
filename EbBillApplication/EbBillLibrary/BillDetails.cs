using System;
namespace EbBillLibrary
{
    public class BillDetails
    {
        private static int s_meterNumber = 1000;
        public string MeterId { get; }
        public string CustomerName { get; set; } //Auto Property
        public string FatherName { get; set; }
        public long MobileNumber { get; set; }
        public string EmailId { get; set; }
        
        

        public BillDetails(string name,string fatherName,long mobileNumber, string emailId)
        {
            s_meterNumber++;
            MeterId = "TNEB"+s_meterNumber;
            CustomerName = name;
            FatherName =fatherName;
            MobileNumber = mobileNumber;
            EmailId=emailId;
            
        }     
        public void Display()
        {
            Console.WriteLine("\nCustomer Details:");
            Console.WriteLine($"Account Number: {MeterId} \nName: {CustomerName} \nFather's Name: {FatherName} \nMobile Number: {MobileNumber} \nEmail Id: {EmailId} ");
        }
        public double RegisterNoOfUnits()
        {
            Console.WriteLine("Enter the number of units used:");
            double noOfUnits = double.Parse(Console.ReadLine());
            return noOfUnits;
        }
        public void CalculateBill(double units)
        {
            double moneyForUnits=0;

            if(units>400)
            {  
                moneyForUnits= 50 +(100*2)+(200*4)+(units-400)*6 ;
            }
            else if(units>200 && units<=400)
            {
                moneyForUnits = 50+(100*2)+(units-200)*4;
            }
            else if(units>100&&units<=200)
            {
                moneyForUnits=50+(units-100)*2;                
            }
            else if(units<=100)
            {
                moneyForUnits = 50;
            }
            Console.WriteLine($"The amount of money for units consumed = {moneyForUnits}");
        }
    }
}