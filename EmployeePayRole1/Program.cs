using System;
using System.Collections.Generic;

namespace EmployeePayRole
{
    class Program
    {
        static List <EmployeeDetails> employeeList = new List<EmployeeDetails>();
        static EmployeeDetails currentUser = null;
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
        }
        static void Default()
        {
            EmployeeDetails employee = new EmployeeDetails("Suba","Kaliamoorthy",new DateTime(12/02/1999),Gender.Female,9876543212,"suba@gmail.com",Location.MathuraTowers);
            employeeList.Add(employee);
        }
        public static void Login()
        {
             Console.WriteLine("Enter your Employee ID:");
            string employeeId = Console.ReadLine().ToUpper();
            
            foreach(EmployeeDetails employee in employeeList)
            {   
                if(employeeId==employee.EmployeeId)
                {
                    Console.WriteLine("Login Successfull!");
                    currentUser=employee;
                    SubMenu();
                }
            }
        }
        public static void SubMenu()
        {
            int option;
        do
        {   
            Console.WriteLine();
            Console.WriteLine("Select Sub Menu:\n1.Display Details \n2.Calculate Salary \n3.Exit");
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
                    currentUser.CalculateSalary();
                    break;
                }
            }
        }while(option!=3);
        Console.WriteLine();   
    
        }
    }

}
   
