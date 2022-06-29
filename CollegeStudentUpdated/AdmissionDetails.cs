using System;

namespace CollegeStudentUpdated
{
    public enum Status{Default,Admitted,Cancelled}
    public class AdmissionDetails
    {
        private static int s_admissionId = 1000;
        public string AdmissionId { get; }
        public string StudentId { get; set; }
        public string DepartmentId { get; set; }
        public DateTime AdmissionDate { get; set; }
        public Status Status { get; set; }
        
        public AdmissionDetails(string studentId,string departmentId,DateTime admissionDate,Status status)
        {
            s_admissionId++;
            AdmissionId ="AID"+1000;
            StudentId = studentId;
            DepartmentId=departmentId;
            AdmissionDate =admissionDate;
            Status = status;
            
        }
        
        
                
    }
}