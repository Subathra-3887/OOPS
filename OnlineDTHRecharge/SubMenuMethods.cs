using System;
namespace OnlineDTHRecharge
{
    public partial class Operations
    {
        public static void CurrentPack()
        {
            int count=0;
            DateTime max= DateTime.Now;
            foreach(RechargeDetails recharge in rechargeList)
            {
                if(recharge.UserId==currentUser.UserId)
                {
                    currentUserList.AddElement(recharge);
                    max = currentUserList[0].RechargeDate;
                    count++;
                }
            }
            for(int i =0;i<currentUserList.Count;i++)
            {
                if(currentUserList[i].RechargeDate> max )
                {
                    max=currentUserList[i].RechargeDate;
                }
            }
            if(count==1)
            {
                foreach(RechargeDetails recharge in currentUserList)
                {
                    foreach(PackDetails pack in packList)
                    {
                        if(recharge.PackId==pack.PackId)
                        {
                            Console.WriteLine($"User ID: {currentUser.UserId} \nPack ID: {pack.PackId} \nRecharge Amount: {pack.Price} \nValid Till: {recharge.ValidTill.ToString("dd/MM/yyyy")} \nNumber of Channels: {pack.Channels}");
                            Console.WriteLine();
                        }
                    }
                }
            }
            foreach(RechargeDetails recharge in currentUserList)
            {
                if(recharge.RechargeDate == max)
                {
                    foreach(PackDetails pack in packList)
                    {
                        if(recharge.PackId==pack.PackId)
                        {
                            Console.WriteLine($"User ID: {currentUser.UserId} \nPack ID: {pack.PackId} \nRecharge Amount: {pack.Price} \nValid Till: {recharge.ValidTill.ToString("dd/MM/yyyy")} \nNumber of Channels: {pack.Channels}");
                        }
                    }
                }
            }
          
        }
        public static void PackRecharge()
        {
            foreach(PackDetails pack in packList)
            {
                Console.WriteLine($"Pack ID: {pack.PackId} \nPack Name: {pack.PackName} \nPrice: {pack.Price} \nValidity(No of Days): {pack.Validity} \nNumber of Channels: {pack.Channels}");
                Console.WriteLine();
            }
            Console.WriteLine("Select the pack using Pack ID:");
            string packId = Console.ReadLine().ToUpper();
            foreach (PackDetails pack in packList)
            {
                if(packId == pack.PackId)
                {
                    if(currentUser.WalletBalance>=pack.Price)
                    {
                        currentUser.WalletBalance = currentUser.WalletBalance-pack.Price;
                        DateTime rechargeDate = DateTime.Now;
                        DateTime validTill = rechargeDate.AddDays(pack.Validity);
                        RechargeDetails recharge = new RechargeDetails(packId,currentUser.UserId,rechargeDate,validTill);
                        rechargeList.AddElement(recharge);
                        Console.WriteLine("Recharged Successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Please recharge your wallet");
                    }
                }
            }
        }
        public static void WalletRecharge()
        {
            Console.WriteLine($"Your current balance: {currentUser.WalletBalance}");
            string ans ="yes";
            Console.WriteLine("Do you want to recharge your account? (Yes/No)");
            ans = Console.ReadLine();
            if(ans == "yes")
            {
                Console.WriteLine("Enter the amount you need to recharge:");
                double amount = double.Parse(Console.ReadLine());
                currentUser.WalletBalance = currentUser.WalletBalance + amount;
                Console.WriteLine($"Your updated current balance is {currentUser.WalletBalance}");
            }
            else
            {
                Console.WriteLine("Thank you! Recharge next time");
            }
        }
        public static void RechargeHistory()
        {
            foreach(RechargeDetails recharge in rechargeList)
            {
                if(recharge.UserId == currentUser.UserId)
                {
                    Console.WriteLine($"Recharge ID: {recharge.RechargeId} \nPack ID: {recharge.PackId} \nUser ID: {recharge.UserId} \nRecharge Date: {recharge.RechargeDate.ToString("dd/MM/yyyy")} \nValid Till: {recharge.ValidTill.ToString("dd/MM/yyyy")}");
                    Console.WriteLine();
                }
            }
        }
    }
}