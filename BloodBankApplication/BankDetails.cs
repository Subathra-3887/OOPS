using System;

namespace BloodBankApplication
{
    public enum BloodGroup {Default,A_Positive,B_Positive,O_Positive,AB_Positive}
    public class BankDetails
    {
        private static int s_donorId = 1000;
        public string  DonorId { get; }
        public string DonorName { get; set; }
        public long MobileNumber  { get; set; }
        public BloodGroup BloodGroup { get; set; }        
        public int Age { get; set; }
        public DateTime LastDonation { get; set; }

        public BankDetails (string name, long mobileNumber, BloodGroup bloodGroup, int age, DateTime lastDonation)
    {
        s_donorId++;
        DonorId = "BD"+s_donorId;
        DonorName=name;
        MobileNumber=mobileNumber;
        BloodGroup = bloodGroup;
        Age = age;
        LastDonation = lastDonation;
    }
    
    }
    
}