using System;

namespace  HybridInheritance
{
    
    class Program
    {

        public static void Main(string[] args)
        {
            
            EmployeeRegister   employee=new EmployeeRegister();

            employee.StudentName="Subathra";
            employee.FatherName="Kaliamoorthy";
            employee.Age=23;
            employee.Gender="Female";
            employee.MobileNumber=9876543212;

            employee.DoorNo=28;
            employee.Address="Anjaneyar Kovil street, Pondicherry";

            employee.TotalSSLC=486;
            employee.TotalHSC=1074;
            
            employee.TotalCollegeCGPA=8.64;
            employee.Date=DateTime.Now;
           

           employee.DisplayStudentInfo();
           employee.DisplayHomeInfo();
           employee.DisplayEducationDetails();
           employee.DisplayEmployeeDetails();
        

        }
    }
}