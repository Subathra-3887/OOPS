using System;
using System.Collections.Generic;
namespace JobApply
{
    class Program
    {
        static List<UserDetails> userList = new List<UserDetails>();
        static List<RecruiterDetails> recList = new List<RecruiterDetails>();
        static List<JobDetails> jobList = new List<JobDetails>();
        static List<AppliedJobs> appliesList = new List<AppliedJobs>();
        static List<RecruiterAction> actionList = new List<RecruiterAction>();
        static UserDetails currentUser=null;
        static RecruiterDetails recUser = null;
        static void Main(string[] args)
        {
            AddDefault();
            string ans="yes";
            int option;
            do
            {
                Console.WriteLine("Main Menu: \n1.User Registration \n2.Login \n3.Exit");
                option = int.Parse(Console.ReadLine());
            switch(option)
            {
                case 1:
                    {
                        Console.WriteLine("Select your role: \n1.User Registration \n2.Recruiter Registration");
                        int option1 = int.Parse(Console.ReadLine());
                        if(option1==1){UserRegistration();}
                        else{RecruiterRegistration();}
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Select your role: \n1.User Login \n2.Recruiter Login");
                        int option1 = int.Parse(Console.ReadLine());
                        if(option1==1){UserLogin();}
                        else{RecruiterLogin();}
                        break;
                    }
                case 3:
                    {
                        ans ="no";
                        break;
                    }
                }
            }while(ans=="yes");
        }
        public static void UserRegistration()
        {
            Console.WriteLine("Enter your Name:");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter your age:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Select your Gender: \n1.Male \n2.Female \n3.Others");
            int genderVelue = int.Parse(Console.ReadLine());
            Gender gender = (Gender)genderVelue;
            Console.WriteLine("Enter your SSLC Marks:");
            int sslcMarks = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your HSC Marks:");
            int hscMarks = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your UG Degree:");
            string ugDegree= Console.ReadLine();
            Console.WriteLine("Enter your UG Grade:");
            double ugGrade = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter your role:");
            string role = Console.ReadLine();

            UserDetails user = new UserDetails(userName,age,gender,sslcMarks,hscMarks,ugDegree,ugGrade,role);
            userList.Add(user);
            Console.WriteLine($"User ID: {user.UserId}");
        }
        public static void RecruiterRegistration()
        {
            Console.WriteLine("Enter your Name");
            string recName= Console.ReadLine();
            Console.WriteLine("Enter your position:");
            string position = Console.ReadLine();
            Console.WriteLine("Enter your Company Name:");
            string companyName =Console.ReadLine();
            Console.WriteLine("Enter your role:");
            string role = Console.ReadLine();
            RecruiterDetails recruiter = new RecruiterDetails(recName,position,companyName,role);
            recList.Add(recruiter);
            Console.WriteLine($"Recruiter ID: {recruiter.RecId}");
        }
        public static void UserLogin()
        {
            Console.WriteLine("Enter your user ID:");
            string userId = Console.ReadLine().ToUpper();
            foreach(UserDetails user in userList)
            {
                if(userId==user.UserId)
                {
                    Console.WriteLine("Login Successfull");
                    currentUser = user;
                    string ans = "yes";
                     do
                    {
                        Console.WriteLine("Sub Menu: \n1.Job Search \n2.Applied Jobs \n3.Recruiter Action \n4.Exit");
                        int option = int.Parse(Console.ReadLine());
                        switch(option)
                        {
                            case 1:
                            {
                                JobApply();
                                break;
                            }
                            case 2:
                            {
                                AppliedJobs();
                                break;
                            }
                            case 3:
                            {
                                RecruiterAction();
                                break;
                            }
                            case 4:
                            {   
                                ans = "no";
                                break;
                            }
                        }
                    }while(ans=="yes");
                }
            }
        }
        public static void RecruiterLogin()
        {
            Console.WriteLine("Enter your recruiter ID:");
            string recId = Console.ReadLine().ToUpper();
            foreach(RecruiterDetails recruiter in recList)
            {
                if(recId==recruiter.RecId)
                {
                    Console.WriteLine("Login Successfull");
                    recUser = recruiter;
                    string ans = "yes";
                    do
                    {
                        Console.WriteLine("Sub Menu: \n1.Job Seekers Profile \n2.Exit");
                        int option = int.Parse(Console.ReadLine());
                        switch(option)
                        {
                            case 1:
                            {
                                JobSeekersProfile();
                                break;
                            }
                            case 2:
                            {   
                                ans = "no";
                                break;
                            }
                        }
                    }while(ans=="yes");
                }   
            } 
        }
        public static void JobApply()
        {
            Console.WriteLine("Enter the job Name you look for:");
            string jobName = Console.ReadLine();
            Console.WriteLine("Enter the location you look for:");
            string location = Console.ReadLine();
            Console.WriteLine("Enter the experience your look for:");
            int experience = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the salary you look for");
            int salary = int.Parse(Console.ReadLine());
            Console.WriteLine("JOB DETAILS");

            foreach(JobDetails jobs in jobList)
            {
                if(jobName ==jobs.JobName && experience == jobs.Experience && salary == jobs.Salary)
                {
                Console.WriteLine($"Job Id: {jobs.JobId} \nJob Name: {jobs.JobName} \nLocation: {jobs.Location} \nExperience: {jobs.Experience} \nSalary: {jobs.Salary}");
                Console.WriteLine();
                }
            }
            Console.WriteLine("Select the job using job id:");
            string jobId = Console.ReadLine();
            foreach(JobDetails jobs in jobList)
            {
                if(jobId == jobs.JobId)
                {
                    AppliedJobs applied = new AppliedJobs(jobs.JobId,jobs.JobName,jobs.Location,jobs.Experience,jobs.Salary,Status.Applied);
                    appliesList.Add(applied);
                }
            }
        }
        public static void AppliedJobs()
        {
            foreach(AppliedJobs applied in appliesList)
            {
                Console.WriteLine($"Job ID: {applied.JobId} \nJob Name: {applied.JobName} \nJob Location: {applied.Location} \nExperience: {applied.Experience} \nSalary: {applied.Salary} \nStatus: {applied.Status}");
                Console.WriteLine();
            }
        }
        public static void RecruiterAction()
        {
            foreach(RecruiterAction action in actionList)
            {
                Console.WriteLine($"Recruiter ID: {action.RecId} \nPosition: {action.Position} \nCompany Name: {action.CompanyName} \nAction: {action.Action}");
                Console.WriteLine();
            }
        }
        public static void JobSeekersProfile()
        {
            foreach(UserDetails user in userList)
            {
                Console.WriteLine($"User ID: {user.UserId} \nUser Name: {user.UserName} \nAge: {user.Age} \nGender: {user.Gender} \nSSLC Marks: {user.SSLCMarks} \nHSC Marks: {user.HSCMarks} \nUG Degree: {user.UGDegree} \nUG Grade: {user.UGGrade}");
                Console.WriteLine();
            }
            Console.WriteLine("Enter the user ID to be selected:");
            string userId = Console.ReadLine();
            Console.WriteLine("Enter the review to be mentioned:");
            string action = Console.ReadLine();
            RecruiterAction actions = new RecruiterAction(recUser.RecId,userId,recUser.Position,recUser.CompanyName,action);
            actionList.Add(actions);
        }
        public static void AddDefault()
        {
            JobDetails job1 = new JobDetails("Software Developer","Anna Nagar",2,20000);
            jobList.Add(job1);
            JobDetails job2 = new JobDetails("Tester","Kizhpauk",2,10000);
            jobList.Add(job2);
            JobDetails job3 = new JobDetails("Full Stack Developer","Navalur",2,50000);
            jobList.Add(job3);
            JobDetails job4 = new JobDetails("Software Developer","Thambaram",2,20000);
            jobList.Add(job4);
            JobDetails job5 = new JobDetails("Tester","Anna Nagar",1,15000);
            jobList.Add(job5);

            UserDetails user1 = new UserDetails("Suba",23,Gender.Female,480,1074,"B.Tech(Chemical)",8.64,"user");
            userList.Add(user1);
            UserDetails user2 = new UserDetails("Usha",33,Gender.Female,476,1064,"B.Tech(IT)",8.72,"user");
            userList.Add(user2);
            UserDetails user3 = new UserDetails("Prasat",36,Gender.Male,465,1001,"B.Tech(CSC)",8.34,"user");
            userList.Add(user3);

            RecruiterDetails rec1 = new RecruiterDetails("Ravi","Senior Software Developer","Syncfusion Software","recruiter");
            recList.Add(rec1);
            RecruiterDetails rec2 = new RecruiterDetails("Baskaran","Senior Software Developer","Syncfusion Software","recruiter");
            recList.Add(rec2);

            RecruiterAction action1 = new RecruiterAction("RID2001","UID1001","Senior Software Developer","Syncfusion Software","Please contact the following email ID: ravi@gmail.com for your interview process");
            actionList.Add(action1);
            RecruiterAction action2 = new RecruiterAction("RID2001","UID1002","Senior Software Developer","Syncfusion Software","Please contact the following email ID: ravi@gmail.com for your interview process");
            actionList.Add(action2);
        }
    }

}
   
