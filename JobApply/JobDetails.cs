using System;
namespace JobApply
{
    public class JobDetails
    {
        private static int s_jobId = 3000;
        public string JobId { get; }
        public string JobName { get; set; }
        public string Location { get; set; }
        public int Experience { get; set; }
        public int Salary { get; set; }
        public JobDetails(string jobName,string location,int experience,int salary)
        {
            s_jobId++;
            JobId ="JID"+s_jobId;
            JobName= jobName;
            Location=location;
            Experience=experience;
            Salary=salary;
        }        
    }
}