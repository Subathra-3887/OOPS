namespace OnlineMedicalStore
{
    public class UserDetails
    {
        private static int s_userId = 1000;
        public string UserId { get;  }
        public string UserName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public long PhoneNumber { get; set; }
        public double Balance { get; set; }
        
        public UserDetails(string userName,int age,string city,long phoneNumber,double balance)
        {
            s_userId++;
            UserId = "UID"+s_userId;
            UserName=userName;
            Age=age;
            City=city;
            PhoneNumber=phoneNumber;
            Balance=balance;
        }
        
        
        
        
        
    }
}