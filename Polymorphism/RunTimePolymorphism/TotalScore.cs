using System;
namespace RunTimePolymorphism
{
    public class TotalScore:SportsInfo
    {   
        public double FinalMark { get; set; }
        
        
     public override void Display()
     {
         FinalMark =TotalMarks+SportScore;
         Console.WriteLine($"Name: {StudentName} \nFinal Marks: {FinalMark}");
     }
        
    }
}