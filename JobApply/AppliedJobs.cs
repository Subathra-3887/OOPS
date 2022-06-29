using System;
namespace JobApply
{   
    public enum Status {Default,Applied}
    public class AppliedJobs
    {
        public string JobId { get; }
        public string JobName { get; set; }
        public string Location { get; set; }
        public int Experience { get; set; }
        public int Salary { get; set; }
        public Status Status { get; set; }

        public AppliedJobs(string jobId,string jobName,string location,int experience,int salary,Status status)
        {

            JobId = jobId;
            JobName= jobName;
            Location=location;
            Experience=experience;
            Salary=salary;
            Status=status;
        }        
    }
}