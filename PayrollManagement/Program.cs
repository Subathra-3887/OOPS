using System;
using System.Collections.Generic;

namespace PayrollManagement
{
    class Program
    {
        static List<EmployeeDetails> employeeList = new List<EmployeeDetails>();
        static List<WorklogDetails> worklogList = new List<WorklogDetails>();
        static EmployeeDetails currentUser = null;
        static void Main(string[] args)
        {
            Default();
            int option;
            do
            {
                Console.WriteLine("Select Main Menu");
                Console.WriteLine("1.AddNewEmployee\n2.ExistingEmployeeLogin\n3.Exit");
                option = int.Parse(Console.ReadLine());
                switch(option)
            {
                case 1:
                {
                    AddNewEmployee();
                    break;
                }
                case 2:
                {
                    ExistingEmployeeLogin();
                    break;
                }             
            }

            }while(option!=3);
        }
        public static void AddNewEmployee()
        {
            Console.WriteLine("Enter your full name:");
            string employeeName = Console.ReadLine();
            Console.WriteLine("Select your branch: \n1.Eymard \n2.Mathura \n.3.Karuna");
            int branchValue = int.Parse(Console.ReadLine());
            Branch branch = Branch.Default;
            while(!(branchValue>0 && branchValue<4))
            {
                Console.WriteLine("Select your branch: \n1.Eymard \n2.Mathura \n.3.Karuna");
                branchValue = int.Parse(Console.ReadLine());
            }
            branch = (Branch)branchValue;
            Console.WriteLine("Select your team: \n1.Developement \n2.Networking \n.3.HR");
            int teamValue = int.Parse(Console.ReadLine());
            Teams teams = Teams.Default;
            while(!(branchValue>0 && branchValue<4))
            {
                Console.WriteLine("Select your branch: \n1.Eymard \n2.Mathura \n.3.Karuna");
                branchValue = int.Parse(Console.ReadLine());
            }
            teams = (Teams)teamValue;
            EmployeeDetails employee = new EmployeeDetails(employeeName,branch,teams);
            employeeList.Add(employee);
            Console.WriteLine($"Employee ID: {employee.EmployeeId}");
        }
        static void Default()
        {
            EmployeeDetails employee = new EmployeeDetails("Subathra",Branch.Mathura,Teams.Developement);
            employeeList.Add(employee);
        }
        public static void ExistingEmployeeLogin()
        {
                Console.WriteLine("Enter your Employee Id:");
                string employeeId = Console.ReadLine().ToUpper();
                foreach(EmployeeDetails employee in employeeList)
                {
                    if(employeeId == employee.EmployeeId)
                    {
                        Console.WriteLine("Login Successfull");
                        currentUser = employee;
                        SubMenu();
                    }
                }
        }
        public static void SubMenu()
        {
            int option;
            do
            {
                Console.WriteLine("SubMenu: \n1.Show Details \n2.Calculate Salary \n3.Exit");
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
                        CalculateSalary();
                        break;
                    }
                }
            }while(option!=3); 

        }
        public static void CalculateSalary()
        {
            string employeeId = currentUser.EmployeeId;
            Console.WriteLine("Enter your check in time:");
            DateTime checkIn = DateTime.ParseExact(Console.ReadLine(),"hh:mm tt",null);
            Console.WriteLine("Enter your check out time:");
            DateTime checkOut = DateTime.ParseExact(Console.ReadLine(),"hh:mm tt",null); 
            TimeSpan diff = checkOut-checkIn;
            string workHours = diff.ToString();
            
        }
    }

}
   
