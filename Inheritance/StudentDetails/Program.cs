using System;

namespace StudentDetails
{
    class Program
    {
        static void Main(string[] args)
        {
            
            HSCMarks student = new HSCMarks();
            student.Name="Subathra";
            student.FatherName="Kaliamoorthy";
            student.Physics = 123;
            student.Chemistry = 121;
            student.Maths = 134;
            student.ShowHSCMarks();
            UGDetails collegeStudent = new UGDetails();
            collegeStudent.Name = "Subathra";
            collegeStudent.FatherName = "Kaliamoorthy";
            collegeStudent.Sem1Marks = 8.9;
            collegeStudent.Sem2Marks = 7.8;
            collegeStudent.Sem3Marks = 8.6;
            collegeStudent.Sem4Marks =7.7;
            collegeStudent.ShowUGMarks();
            UGDetails info = new UGDetails();
            info.Name = "Subathra";
            info.FatherName = "Kaliamoorthy";
            info.Physics = 123;
            info.Chemistry=121;
            info.Maths= 145;
            info.Sem1Marks=8.9;
            info.Sem2Marks=7.8;
            info.Sem3Marks=8.8;
            info.Sem4Marks=7.8;
            info.ShowUGMarks();
            info.ShowHSCMarks();
            info.CalculateHSCScore();
            info.CalculateUGScore();
        }
    }

}
   
