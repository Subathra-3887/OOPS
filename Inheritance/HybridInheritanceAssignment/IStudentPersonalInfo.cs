namespace HybridInheritance
{
    
    interface IStudentPersonalInfo
    {
        string StudentName { get; set; }
        string FatherName { get; set; }
        long MobileNumber { get; set; }
        int Age { get; set; }
        string Gender { get; set; }
       
       void DisplayStudentInfo();
        
    }
}
   
