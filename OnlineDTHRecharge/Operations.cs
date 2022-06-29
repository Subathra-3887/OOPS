using System;
using System.Collections.Generic;
namespace OnlineDTHRecharge
{
    public partial class Operations
    {
        public static List<UserDetails> userList = new List<UserDetails>();
        public static List<PackDetails> packList = new List<PackDetails>();
        public static List<RechargeDetails> rechargeList = new List<RechargeDetails>();
        static List<RechargeDetails> currentUserList = new List<RechargeDetails>();
        public static UserDetails currentUser = null;
        public static void ShowMainMenu()
        {
            int option;
            string ans = "yes";
            do
            {   Console.WriteLine("***MAIN MENU*** \n1.User Registration \n2.User Login \n3.Exit");
                option=int.Parse(Console.ReadLine());
                switch(option)
                {
                    case 1:
                    {
                        UserRegistration();
                        break;
                    }
                    case 2:
                    {
                        UserLogin();
                        break;
                    }
                    case 3:
                    {
                        ans ="no";
                        break;
                    }
                }
            }while(ans=="yes");
        }
        public static void UserRegistration()
        {
            Console.WriteLine("Enter your Name:");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter your Mobile Number:");
            long mobileNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Email ID:");
            string emailId = Console.ReadLine();
            Console.WriteLine("Enter the amount in your wallet:");
            double walletBalance = double.Parse(Console.ReadLine());

            UserDetails user = new UserDetails(userName,mobileNumber,emailId,walletBalance);
            userList.AddElement(user);
            Console.WriteLine($"User ID: {user.UserId}");
        }
        public static void UserLogin()
        {
            Console.WriteLine("Enter your User ID:");
            string userId = Console.ReadLine().ToUpper();
            string element = userId;
            int answer = BinarySearch(userList,element,out currentUser);
            if(answer!=-1)
            {
                ShowSubMenu();
            }
            else
            {
                Console.WriteLine("Invalid User ID");
            }
            static int BinarySearch(List<UserDetails>userList,string element,out UserDetails user)
            {
                int left = 0,right = userList.Count-1;
                while(left<=right)
                {
                    int middle = left+(right-left)/2;
                    if(userList[middle].UserId==element)
                    {
                        user = userList[middle];
                        return middle;
                    }
                    if(userList[middle].UserId.CompareTo(element)<0)
                    {
                        left = middle+1;
                    }
                    else
                    {
                        right=middle-1;
                    }
                }
                user=null;
                return-1;
            }
        }
        public static void ShowSubMenu()
        {
            char option;
            string ans = "yes";
            do
            {
                Console.WriteLine("***SUB MENU*** \na.Current Pack \nb.Pack Recharge \nc.Wallet Recharge \nd.View Pack Recharge History \ne.Exit");
                option = char.Parse(Console.ReadLine().ToLower());
                switch(option)
                {
                    case 'a':
                    {
                        CurrentPack();
                        break;
                    }
                    case 'b':
                    {
                        PackRecharge();
                        break;
                    }
                    case 'c':
                    {
                        WalletRecharge();
                        break;
                    }
                    case 'd':
                    {
                        RechargeHistory();
                        break;
                    }
                    case 'e':
                    {
                        ans = "no";
                        break;
                    }
                }
            }while(ans=="yes");
        }
        
    }
}