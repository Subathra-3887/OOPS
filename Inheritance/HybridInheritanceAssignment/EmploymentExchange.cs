using System;
namespace HybridInheritance
{
    public class EmployeeRegister:IStudentPersonalInfo,IHomeInfo,IEducationDetails
    {
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public int Age  { get; set; }
        public long MobileNumber { get; set; }
        public string Gender { get; set; }

          
        public int DoorNo { get; set; }
          
        public string Address { get; set;}
        
        public double TotalSSLC { get; set; }
        public double TotalHSC { get; set; }
        public double TotalCollegeCGPA { get; set; }


       

        private static int  RegisterNumber = 10000;

        public DateTime Date { get; set; }
           
           

         public void DisplayEmployeeDetails()
        {
            RegisterNumber++;
            Console.WriteLine($"RegisterNumber: {RegisterNumber} \nDate of Register : {DateTime.Now}");
        }

          public void DisplayStudentInfo()
        {
            Console.WriteLine($"Student name is {StudentName} \nFather Name is {FatherName} \nAge {Age}\nMobile Number {MobileNumber}\nGender {Gender} ");
        }

        public void DisplayHomeInfo()
       {

           Console.WriteLine($"Door Number : {DoorNo} \nAddress : {Address} ");
       }


      public void DisplayEducationDetails()
      {
        Console.WriteLine($"SSLC Mark Total:  {TotalSSLC} \nHSC Mark Total  {TotalHSC} \nOverallCGPA : {TotalCollegeCGPA}");
      }

      

    }
}