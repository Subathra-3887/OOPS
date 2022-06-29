namespace StudentDetails
{
    public class PersonalInfo
    {
        public string Name { get; set; }
        public string FatherName { get; set; }
        
        public void DisplayPersonalInfo()
        {
            Console.WriteLine($"Student name :{Name}");
            Console.WriteLine($"Student's father name:{FatherName}");
        }
        
    }
}