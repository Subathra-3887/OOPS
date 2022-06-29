using System;
namespace RunTimePolymorphism
{
    public class SportsInfo:StudentInfo
    {
        public double SportScore =50;

        
        public override void Display()
        {
            Console.WriteLine($"Name: {StudentName} \nSport Score:{SportScore}");
        }
    }
}