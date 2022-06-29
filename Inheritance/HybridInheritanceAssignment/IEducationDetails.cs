namespace HybridInheritance
{
    interface IEducationDetails:IStudentPersonalInfo
    {
        double TotalSSLC { get; set; }
        double TotalHSC { get; set; }
        double TotalCollegeCGPA { get; set; }
        
        void DisplayEducationDetails();
        
        
    }
}