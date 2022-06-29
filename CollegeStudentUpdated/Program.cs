using System;
using System.IO;
using System.Collections.Generic;

namespace CollegeStudentUpdated
{

    class Program
    {
        static void Main(string[] args)
        {
            Operations.ShowStudentDetails();
            Operations.DepartmentDetails();
            Operations.DefaultAdmissionDetails();
            
            Operations.ShowMainMenu();

            Operations.Insert(Operations.studentList);
            Operations.Insert(Operations.departmentList);
            Operations.Insert(Operations.admissionList);
        }
        
        
    }

}
        
