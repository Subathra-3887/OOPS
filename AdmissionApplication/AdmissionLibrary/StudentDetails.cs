using System;

namespace AdmissionLibrary
{
    public enum Gender{Default,Male,Female,Others}
    public class StudentDetails
    {   
        private static int s_registrationNumber=3000;//Field
        public string RegistrationId {get;} //Property
        public string StudentName { get; set; } //Auto Property
        public string FatherName { get; set; }
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        public long MobileNumber { get; set; }
        public string EmailId { get; set; }
        public int Physics { get; set; }
        public int Chemistry { get; set; }
        public int Maths { get; set; }
         //Parameterized constructor
        public StudentDetails(string name,string fatherName,DateTime dob, Gender gender,long mobileNumber,string emailId,int physics,int chemistry,int maths)
        {
            s_registrationNumber++;
            RegistrationId = "SF"+s_registrationNumber;
            StudentName = name;
            FatherName = fatherName;
            DOB = dob;
            Gender = gender;
            MobileNumber = mobileNumber;
            EmailId = emailId;
            Physics = physics;
            Chemistry = chemistry;
            Maths = maths;
        }
        public void Display()  //Method
        {
            Console.WriteLine("\nStudent Details:");
            Console.WriteLine($"Registration Number: {RegistrationId} \nName: {StudentName} \nFather's Name: {FatherName} \nDOB: {DOB} \nGender: {Gender} \nMobile Number: {MobileNumber} \nEmail Id: {EmailId} \nPhysics: {Physics} \nChemistry: {Chemistry} \nMaths: {Maths}");
            
        }
        public bool CheckEligibility(double cutOff)
        {
            double average = (double)(Maths+Chemistry+Physics)/3;
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
   
