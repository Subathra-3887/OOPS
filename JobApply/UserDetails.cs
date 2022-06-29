using System;
namespace JobApply
{
    public enum Gender {Default,Male,Female,Others}
    public class UserDetails
    {
        private static int s_userId = 1000;
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public int SSLCMarks { get; set; }
        public int HSCMarks { get; set; }
        public string UGDegree { get; set; }
        public double UGGrade { get; set; }
        public string Role { get; set; }
        
        
        public UserDetails(string userName,int age,Gender gender,int sslcMarks,int hscMarks,string ugDegree,double ugGrade,string role)
        {
            s_userId++;
            UserId = "UID"+s_userId;
            UserName=userName;
            Age=age;
            Gender=gender;
            SSLCMarks=sslcMarks;
            HSCMarks=hscMarks;
            UGDegree=ugDegree;
            UGGrade=ugGrade;
        }
    }
}