namespace StudentDetails
{
    interface ICalculateHSC  //full abstraction
    {
        int Total { get; set; }
        double Average { get; set; }
        
        void CalculateHSCScore();
            
    }
}