using System;
namespace RunTimePolymorphism
{
    public class StudentInfo
    {
        public string StudentName { get; set; }
        public double TotalMarks { get; set; }
        
        public virtual void Display()
        {
           
        }
        
    }
}