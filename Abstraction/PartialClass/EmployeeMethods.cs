using System;
namespace PartialClass
{
    public partial class EmployeeInfo
    {
        public EmployeeInfo (string employeeId,string name)
        {
            EmployeeId =employeeId;
            EmployeeName = name;
        }
        public void DisplayEmpInfo()
        {
            Console.WriteLine($"Employee ID: {EmployeeId} \nEmployee Name: {EmployeeName}");
        }
    }
}