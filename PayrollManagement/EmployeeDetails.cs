using System;
namespace PayrollManagement
{
    public enum Branch {Default,Eymard,Mathura,Karuna}
    public enum Teams {Default,Developement,Networking,HR}
    public class EmployeeDetails
    {
        private static int s_employeeId = 3000;
        public string EmployeeId { get; }
        public string EmployeeName { get; set; }
        public Branch Branch { get; set; }
        public Teams Teams { get; set; }
        
        public EmployeeDetails(string employeeName,Branch branch,Teams teams)
        {
            s_employeeId++;
            EmployeeId = "SF"+s_employeeId;
            EmployeeName = employeeName;
            Branch=branch;
            Teams=teams;
        }
        public void Display()
        {
            Console.WriteLine("\nEmployee Details");
            Console.WriteLine($"Employee ID: {EmployeeId} \nEmployee Name: {EmployeeName} \nBranch: {Branch} \nTeam: {Teams}");
        }
        
    }
}