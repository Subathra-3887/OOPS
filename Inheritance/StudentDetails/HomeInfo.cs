namespace StudentDetails
{
    public class HomeInfo:PersonalInfo
    {
        public int DoorNo { get; set; }
        public string Address { get; set; }
        
        public void ShowHomeDetails()
        {
            DisplayPersonalInfo();
            Console.WriteLine($"Residential Address: {DoorNo}, {Address}");
        }
    }
}