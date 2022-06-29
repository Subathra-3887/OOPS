namespace StudentDetails
{
    public class HSCMarks:PersonalInfo,ICalculateHSC
    {
        public int Physics { get; set; }
        public int Chemistry { get; set; }
        public int Maths   {get; set;}
        public int Total { get; set; }
        public double Average { get; set; }
        public void ShowHSCMarks()
        {
            DisplayPersonalInfo();
            Console.WriteLine($"Your Marks: \nPhysics: {Physics} \nChemistry: {Chemistry} \nMaths: {Maths}");
        }
        public void CalculateHSCScore()
        {
            int Total = Physics+Chemistry+Maths;
            double Average = (Physics+Chemistry+Maths)/3;
            Console.WriteLine($"Total HSC Marks: {Total} \tAverage of HSC Marks: {Average}");
        }
        
    }
}