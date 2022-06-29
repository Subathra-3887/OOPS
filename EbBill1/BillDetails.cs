using System;
namespace EbBill
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
            MeterId = "EB"+s_meterNumber;
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
       
        public void CalculateBill()
        {
            Console.WriteLine("Enter the number of units used:");
            double noOfUnits = double.Parse(Console.ReadLine());
            double moneyForUnits=0;
            Console.WriteLine($"Bill ID: {MeterId}");
            Console.WriteLine($"Name: {CustomerName}");
            Console.WriteLine($"Untits: {noOfUnits}");

            if(noOfUnits>400)
            {  
                moneyForUnits= 50 +(100*2)+(200*4)+(noOfUnits-400)*6 ;
            }
            else if(noOfUnits>200 && noOfUnits<=400)
            {
                moneyForUnits = 50+(100*2)+(noOfUnits-200)*4;
            }
            else if(noOfUnits>100&& noOfUnits<=200)
            {
                moneyForUnits=50+(noOfUnits-100)*2;                
            }
            else if(noOfUnits<=100)
            {
                moneyForUnits = 50;
            }
            Console.WriteLine($"The amount of money for units consumed = {moneyForUnits}");
            
        }
    }
}