namespace MovieTicketBooking
{
    public class UserDetails
    {
        private static int s_userId=1000;
        public string UserId { get; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public long PhoneNumber { get; set; }
        public double WalletBalance { get; set; }
        
        public UserDetails(string userName,int age,long phoneNumber,double walletBalance)
        {
            s_userId++;
            UserId="UID"+s_userId;
            UserName=userName;
            Age=age;
            PhoneNumber=phoneNumber;
            WalletBalance=walletBalance;
        
        }
        
    }
}