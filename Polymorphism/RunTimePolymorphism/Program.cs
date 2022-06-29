using System;

namespace RunTimePolymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
           StudentInfo student;
           student = new SportsInfo();
           student.StudentName = "Subathra";
           student.Display();

           student = new TotalScore();
           student.StudentName = "Usha";
           student.TotalMarks = 480;
           student.Display();
        }
    }

}
   
