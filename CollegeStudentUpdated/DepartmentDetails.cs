using System;

namespace CollegeStudentUpdated
{
    public class DepartmentDetails
    {
        private static int s_depId = 100;
        public string DepartmentId { get; }
        public string DepartmentName { get; set; }
        public int Seats { get; set; }
        
        public DepartmentDetails(string departmentName,int seats)
        {
            s_depId++;
            DepartmentId = "DID"+s_depId;
            DepartmentName = departmentName;
            Seats = seats;
        }
        
                
    }
}