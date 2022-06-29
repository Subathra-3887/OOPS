using System;
namespace BloodBankApplication
{
    public class Donation
    {
        private static int s_donationId = 200;
        public string DonationId { get; }
        public string DonorId { get; set; }
        public int Weight { get; set; }
        public string BloodPressure { get; set; }
        public float HaemogloginCount { get; set; } 
        public DateTime DonationDate  { get; set; }
        
        public Donation(string donorId,int weight,string bloodPressure, float haemoglobinCount,DateTime donationDate)
        {
            s_donationId++;
            DonationId = "DBO"+s_donationId;
            DonorId = donorId;
            Weight=weight;
            BloodPressure= bloodPressure;
            HaemogloginCount= haemoglobinCount;
            DonationDate=donationDate;
        }
        public void NextEligibleDate()
        {
            DateTime nextDate = DonationDate.AddDays(56);
            string date = nextDate.ToString();
            Console.WriteLine($"The next eligible date for donation is: {date}");
        }
        
        
    }
    }