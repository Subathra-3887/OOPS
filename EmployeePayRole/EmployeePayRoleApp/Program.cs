using System;
using System.Collections.Generic;
using EmployeePayRoleLibrary;
namespace EmployeePayRoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string condition = "";
            List <EmployeeDetails> employeeList = new List<EmployeeDetails>();

            do
            {
            Console.WriteLine("Enter your name:");
            string employeeName = Console.ReadLine();
            Console.WriteLine("Enter your father's name:");
            string fatherName =Console.ReadLine();
            Console.WriteLine("Enter your DOB:");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            Console.WriteLine("Select your gender: 1.Male 2.Female 3.Others");
            int genderValue = int.Parse(Console.ReadLine());
            Gender gender = Gender.Default;
            while(!(genderValue>0&&genderValue<4))
            {
                 Console.WriteLine("Select your gender: \n1.Male \n2.Female \n3.Others");
                 genderValue = int.Parse(Console.ReadLine());
            }
            gender = (Gender)genderValue;
            Console.WriteLine("Enter your mobile number:");
            long mobileNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter your email id:");
            string emailId = Console.ReadLine();
            Console.WriteLine("Select your location:\n1.Mathura Towers \n2.Eymard Complex \n3.Karuna Complex");
            int locationValue = int.Parse(Console.ReadLine());
            Location location = Location.Default;
            while(!(locationValue>0&&locationValue<4))
            {
                Console.WriteLine("Enter your location:");
                locationValue = int.Parse(Console.ReadLine());
            }
            location = (Location)locationValue;
            EmployeeDetails employee = new EmployeeDetails(employeeName,fatherName,dob, gender,mobileNumber, emailId, location);
            Console.WriteLine($"Registration Id:{employee.EmployeeId}");
            employeeList.Add(employee);
            Console.WriteLine("Do you want to continue? (Yes/No)"); 
            condition = Console.ReadLine().ToLower();

            }while(condition=="yes");

            Console.WriteLine("Enter your Employee ID:");
            string employeeId = Console.ReadLine().ToUpper();
            
            foreach(EmployeeDetails employee in employeeList)
            {   
                if(employeeId==employee.EmployeeId)
                {
                employee.Display();
                employee.NoofLeaves();
                employee.CalculateSalary(); 
                }
            }



        }
    }

}
   
