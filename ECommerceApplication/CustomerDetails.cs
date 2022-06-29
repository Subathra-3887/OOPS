using System;
namespace ECommerceApplication
{
    public class CustomerDetails
    {
        private static int s_cusId=1000;
        public string CustomerId { get;}
        public string CustomerName { get; set; }
        public string City { get; set; }
        public long MobileNumber { get; set; }
        public double WalletBalance { get; set; }
        public string EmailId { get; set; }
        
        
        
        public CustomerDetails(string customerName, string city, long mobileNumber,double walletBalance,string emailId)
        {
            s_cusId++;
            CustomerId = "CID"+s_cusId;
            CustomerName=customerName;
            City=city;
            MobileNumber=mobileNumber;
            WalletBalance=walletBalance;
            EmailId =emailId;
        }
     
    }
}