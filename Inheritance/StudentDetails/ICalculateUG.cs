namespace StudentDetails
{
   interface ICalculateUG  //full abstraction
    {
        int Total { get; set; }
        double Average { get; set; }
        
        void CalculateUGScore();
            
    }
}