using System;
namespace CollegeAdmisssion
{
    public enum Gender{Default,Male,Female,Others}
    public class StudentDetails
    {
         public string StudentName { get; set; } //Auto Property
        public string FatherName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public long MobileNumber { get; set; }
        public string EmailId { get; set; }
        public int Physics { get; set; }
        public int Chemistry { get; set; }
        public int Maths { get; set; }

       
    }
}