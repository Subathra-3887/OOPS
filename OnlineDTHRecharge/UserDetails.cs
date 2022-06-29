namespace OnlineDTHRecharge
{
    /// <summary>
    /// Class <see cref = "UserDetails"/> used to collect user's details for the DTH recharge process
    /// </summary>
    /// 
    public class UserDetails
    {
        /// <summary>
        /// Static field used to auto increment and it uniqely idetifies of <see cref = "UserDetails"/> class
        /// </summary>
        private static int s_userId=1000;
        /// <summary>
        /// Property UserId used to provide user Id for the regsitered user in object of <see cref ="PackDetails"/> class
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// Property UserName used to get name of user  in object of <see cref ="PackDetails"/> class
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Property MobileNumber used to provide Mobile number for the user in object of <see cref ="PackDetails"/> class
        /// </summary>
        public long MobileNumber { get; set; }
        /// <summary>
        /// Property EmailId used to provide mail ID for the user in object of <see cref ="PackDetails"/> class
        /// </summary>
        public string EmailId { get; set; }
        /// <summary>
        /// Property WalletBalance used to provide amount in wallet for the user in object of <see cref ="PackDetails"/> class
        /// </summary>
        public double WalletBalance { get; set; }
        public UserDetails(string userName,long mobileNumber,string emailId,double walletBalance)
        {
            s_userId++;
            UserId="UID"+s_userId;
            UserName =userName;
            MobileNumber=mobileNumber;
            EmailId=emailId;
            WalletBalance=walletBalance;
        }
        
        
        
        
        
    }
}