using System;
namespace CollegeStudentUpdated
{
    public enum Gender {Default,Male,Female,Others}
    public class StudentDetails
    {
        private static int s_studentId = 3000;
        public string StudentId{ get; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        public int Physics { get; set; }
        public int Chemistry { get; set; }
        public int Maths { get; set; }
        public StudentDetails(string studentName,string fatherName,DateTime dob,Gender gender,int physics,int chemistry,int maths)
        {
            s_studentId++;
            StudentId = "SF"+s_studentId;
            StudentName=studentName;
            FatherName =fatherName;
            DOB=dob;
            Gender= gender;
            Physics = physics;
            Chemistry= chemistry;
            Maths= maths;
        }

        public bool CheckEligiblity(double cutOff,Filter filter)
        {
             int total = (Chemistry+Physics+Maths);
                    double average = (double) total/3;
                    if(filter(cutOff,average))
                    {

                     return true;
                    }
                    else 
                    {
                        return false;
                    }
                    
        }
        public static bool filter(double cutOff, double average)
        {
            if(average>=cutOff)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        
        
        
        
    }
}