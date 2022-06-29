using System;

namespace EmployeePayRole
{
    public enum Gender{Default,Male,Female,Others};
    public enum Location{Default,MathuraTowers,EymardComplex,Karuna}
    public class EmployeeDetails
    {
        private static int s_employeeId=3000;
        public string EmployeeId {get;} 
         public string EmployeeName { get; set; } 
        public string FatherName { get; set; }
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        public long MobileNumber { get; set; }
        public string EmailId { get; set; }
        public Location Location { get; set; }
        public int Month { get; set; }
        public int Leave { get; set; }
        
        public EmployeeDetails(string name,string fatherName,DateTime dob, Gender gender,long mobileNumber,string emailId,Location location)
        {
            s_employeeId++;
            EmployeeId = "SF"+s_employeeId;
            EmployeeName = name;
            FatherName = fatherName;
            DOB = dob;
            Gender = gender;
            MobileNumber = mobileNumber;
            EmailId = emailId;
            Location= location;
            
        }
        public void Display()
        {
            Console.WriteLine("\nEmployee Details:");
            Console.WriteLine($"Employee Id:{EmployeeId} \nEmployee Name: {EmployeeName} \nFather's Name: {FatherName} \nDOB: {DOB} \nGender: {Gender} \nMobile Number: {MobileNumber} \nEmail Id: {EmailId} \nLocation: {Location} ");
        }
       
        public void CalculateSalary()
        {
            Console.WriteLine("Enter the leave taken month");
            Month = int.Parse(Console.ReadLine());
             
            Console.WriteLine("Enter the number of leaves taken:");
            Leave = int.Parse(Console.ReadLine());  
            DateTime date = new DateTime(2022,Month,1);
            TimeSpan daysinMonth = (date.AddMonths(1)-date);
            int days = daysinMonth.Days;
            int salary = (days-Leave)*500;
            Console.WriteLine($"Your salary for the particular month: {salary}"); 
        }
    }
}