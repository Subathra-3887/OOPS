using System;
using System.Collections.Generic;
using AdmissionLibrary;
namespace AdmissionApp
{
    class Program
    {
        static void Main(string[] args)
        {   
            //Purchase a file
            List<StudentDetails> studentList = new List<StudentDetails>();
            //Copy of template
            
            string condition="";
            do
            {
            Console.WriteLine("Enter your Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your Father's Name:");
            string fatherName = Console.ReadLine();
            Console.WriteLine("Enter your DOB :");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            Console.WriteLine("Select your gender 1.Male 2.Female 3.Others");
            int genderValue = int.Parse(Console.ReadLine());
            Gender gender=Gender.Default;
            while(!(genderValue>0 && genderValue<4))
            {
                Console.WriteLine("Select your gender 1.Male 2.Female 3.Others");
                genderValue = int.Parse(Console.ReadLine());
            }
             gender=(Gender)genderValue;
            Console.WriteLine("Enter your mobile number:");
            long mobileNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter your email Id:");
            string emailId = Console.ReadLine();
            Console.WriteLine("Enter your marks(Physics):");
            int physics = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your marks(Chemistry):");
            int chemistry = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your marks(Mathematics):");
            int maths = int.Parse(Console.ReadLine());

            StudentDetails student1 = new StudentDetails(name,fatherName,dob,gender,mobileNumber,emailId,physics,chemistry,maths);
            Console.WriteLine($"Registration Id:{student1.RegistrationId}");
            //Add printout to file
            studentList.Add(student1);

            Console.WriteLine("Do you want to continue? (Yes/No)"); //
            condition = Console.ReadLine().ToLower();

            }while(condition=="yes");

            Console.WriteLine("Enter your Registration ID:");
            string registrationID = Console.ReadLine().ToUpper();

            foreach(StudentDetails student in studentList)
            {
            
            if(registrationID==student.RegistrationId)
            {
                student.Display();
                bool eligible = student.CheckEligibility(75.0);
                if(eligible)
                {
                    Console.WriteLine("You are eligible for admission");
                }
                else
                {
                    Console.WriteLine("You are not eligible for admission");
                }
            }
            }
        }
    }

}
   
