namespace StudentDetails
{
    public class UGDetails:HSCMarks,ICalculateUG
    {
        public double Sem1Marks { get; set; }
        public double Sem2Marks { get; set; }
        public double Sem3Marks { get; set; }
        public double Sem4Marks { get; set; }
        public int Total1 { get; set; }
        public double Average1 { get; set; }
        
        public void ShowUGMarks()
        {
            DisplayPersonalInfo();
            Console.WriteLine($"Semester 1 Marks:{Sem1Marks} \nSemester 2 Marks:{Sem2Marks} \nSemester 3 Marks:{Sem3Marks} \nSemester 4 Marks:{Sem4Marks}");
        }
        public void CalculateUGScore()
        {
            double Total = Sem1Marks+Sem2Marks+Sem3Marks+Sem4Marks;
            double Average = (Total)/3;
            Console.WriteLine($"Total UG Marks: {Total} \tAverage of UG Marks: {Average}");
        }
    }
}