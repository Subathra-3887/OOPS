using System;
using System.Collections.Generic;

namespace BloodBankApplication
{
    class Program
    {
        static List<BankDetails> donorList = new List<BankDetails>();
        static List<Donation> donationList = new List<Donation>();
        static BankDetails currentUser = null;
        static Donation user = null;
        static void Main(string[] args)
        {
            Default();
            int option;
           do
           {    
                Console.WriteLine();
                Console.WriteLine("Select Main Menu");
                Console.WriteLine("1.Registration \n2.Login \n3.Fetch donor details \n4.Exit");
                option = int.Parse(Console.ReadLine());
                switch(option)
                {
                    case 1:
                    {
                        Registration();
                        break;
                    }
                    case 2:
                    {   
                        Login();
                        break;
                    }
                    case 3:
                    {
                        FetchDonorDetails();
                        break;
                    }
                }
            }while(option!=4);
        }
        public static void Registration()
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your mobile number:");
            long mobileNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Select your blood group:\n1.A_Positive \n2.B_Positive \n3.O_Positive \n4.AB_Positive");
            int groupValue = int.Parse(Console.ReadLine());
            BloodGroup bloodGroup = BloodGroup.Default;
            while(!(groupValue>0 && groupValue<5))
            {
                Console.WriteLine("Select your blood group:\n1.A_Positive \n2.B_Positive \n3.O_Positive \n4.AB_Positive");
                groupValue = int.Parse(Console.ReadLine());
            }
            bloodGroup = (BloodGroup)groupValue;
            Console.WriteLine("Enter your Age:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your last donation date:");
            DateTime lastDonation = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

            BankDetails donor = new BankDetails(name, mobileNumber,bloodGroup,age,lastDonation);
            donorList.Add(donor);
            Console.WriteLine($"Donor Id:{donor.DonorId}");
        }
        static void Default()
        {
            BankDetails donor = new BankDetails("Suba",9876543212,BloodGroup.B_Positive,23,new DateTime(12/02/1999));
            donorList.Add(donor);
        }
        public static void FetchDonorDetails()
        {
            Console.WriteLine("Select your blood group:\n1.A_Positive \n2.B_Positive \n3.O_Positive \n4.AB_Positive");
                int groupValue = int.Parse(Console.ReadLine());
                BloodGroup bloodGroup = BloodGroup.Default;
                while(!(groupValue>0 && groupValue<5))
                {
                    Console.WriteLine("Select your blood group:\n1.A_Positive \n2.B_Positive \n3.O_Positive \n4.AB_Positive");
                    groupValue = int.Parse(Console.ReadLine());
                }
                bloodGroup = (BloodGroup)groupValue;
            foreach(BankDetails donor in donorList)
            {
                
                if(bloodGroup == donor.BloodGroup)
                {
                    Console.WriteLine($"Donor's Name: {donor.DonorName} \nMobile Number: {donor.MobileNumber}");
                }
            }
        }
        public static void Login()
        {
            Console.WriteLine("Enter your Donor ID:");
            string donorId = Console.ReadLine().ToUpper();

            foreach(BankDetails donor in donorList)
            {
                if(donorId==donor.DonorId)
                {
                    Console.WriteLine("Login successfull");
                    currentUser = donor;
                    SubMenu();
                }
            }
        }
        public static void SubMenu()
        {
          int option;
        do
        {   
            Console.WriteLine();
            Console.WriteLine("Select Sub Menu:\n1.Donate Blood \n2.Donation History \n3.Next eligibility date \n4.Exit");
            option = int.Parse(Console.ReadLine());
            switch(option)
            {
                case 1:
                {   
                    DonateBlood();
                    break;
                }
                case 2:
                {
                    DonationHistory();
                    break;
                }
                case 3:
                {
                    user.NextEligibleDate();
                    break;
                }
                
            }
        }while(option!=4);
        Console.WriteLine();  
        }

        public static void DonateBlood()
        {
           Console.WriteLine("Enter your Donor Id:");
           string donorId = Console.ReadLine();
           Console.WriteLine("Enter your weight:");
           int weight = int.Parse(Console.ReadLine());
           Console.WriteLine("Enter your blood pressure:");
           string bloodPressure = Console.ReadLine();
           Console.WriteLine("Enter your Haemoglobin Count:");
           float haemoglobinCount = float.Parse(Console.ReadLine());
            while(haemoglobinCount<13.5)
            {
                Console.Write("Enter The Hemoglobin Count Greater Than 13.5 : ");
                haemoglobinCount = float.Parse(Console.ReadLine());
            }
            Console.WriteLine("Enter your donation date:");
            DateTime donationDate = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
           
           Donation donation = new Donation(donorId,weight,bloodPressure,haemoglobinCount,donationDate);
           donationList.Add(donation);
           Console.WriteLine($"Donation ID : {donation.DonationId}");
        }    
        public static void DonationHistory()
        {
            Console.WriteLine("Enter your Donation Id:");
            string donationId = Console.ReadLine();

            foreach(Donation donation in donationList)
            {
                if(donationId == donation.DonationId)
                {
                    user = donation;
                    Console.WriteLine($"Donor ID: {donation.DonorId} \nDonation ID: {donation.DonationId} \nWeight: {donation.Weight} \nBlood Pressure: {donation.BloodPressure} \nHaemoglobin Count: {donation.HaemogloginCount} \nDonation date: {donation.DonationDate}");
                }
                else
                {
                    Console.WriteLine("Invalid User ID");
                }
            }
        }
        
    }

}


   
