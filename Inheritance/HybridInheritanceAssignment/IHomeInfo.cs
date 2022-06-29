namespace HybridInheritance
{
    interface IHomeInfo:IStudentPersonalInfo
    {
         int DoorNo { get; set; }
         string Address { get; set; }
        
        void DisplayHomeInfo();

    }
}