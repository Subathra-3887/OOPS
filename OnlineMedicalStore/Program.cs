using System;
using System.IO;
using System.Collections.Generic;

namespace OnlineMedicalStore
{
    class Program
    {
        public static List<UserDetails> userList = new List<UserDetails>();
        public static List<MedicineDetails> medicineList = new List<MedicineDetails>();
        public static List<OrderDetails> orderList = new List<OrderDetails>();
        public static UserDetails currentUser = null;
        static void Main(string[] args)
        {
            ReadUserDetails();
            ReadMedicineDetails();
            ReadOrderDetails();
            string ans ="yes";
            int option;
            do
            {
                Console.WriteLine("Main Menu: \n1.User Registration \n2.User Login \n3.Show Order History \n4.Exit");
                option = int.Parse(Console.ReadLine());
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
                        ShowOrderHistory();
                        break;
                    }
                    case 4:
                    {
                        ans = "no";
                        break;
                    }
                }
            }while(ans=="yes");
            Insert(userList);
            Insert(medicineList);
            Insert(orderList);
        }
        public static void UserRegistration()
        {
            Console.WriteLine("Enter your Name:");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter your age");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your City:");
            string city = Console.ReadLine();
            Console.WriteLine("Enter your phone Number:");
            long phoneNumber= long.Parse(Console.ReadLine());
            Console.WriteLine("Enter your balance:");
            double balance = double.Parse(Console.ReadLine());

            UserDetails user = new UserDetails(userName,age,city,phoneNumber,balance);
            userList.AddElement(user);
            Console.WriteLine($"User ID: {user.UserId}");
        }
        public static void UserLogin()
        {
            Console.WriteLine("Enter your User ID: ");
            string userId = Console.ReadLine();
            string element = userId;
            int result = BinarySearch(userList,element,out currentUser);
            if(result==-1)
            {
                Console.WriteLine("Invalid USerID");
            }
            else
            {
                ShowSubMenu();
            }
            static int BinarySearch(List<UserDetails> array,string element,out UserDetails user)
            {
                int left = 0, right = array.Count-1;
                while(left<=right)
                {
                    int middele = left+(right-left)/2;
                    if(array[middele].UserId==element)
                    {
                        user = array[middele];
                        return middele;
                    }
                    if(array[middele].UserId.CompareTo(element)<0)
                    {
                        left=middele+1;
                    }
                    else
                    {
                        right = middele-1;
                    }
                }
                user=null;
                return-1;
            }
        }
        public static void ShowOrderHistory()
        {
            foreach(OrderDetails order in orderList)
            {
                if(order.UserId == currentUser.UserId)
                {
                    Console.WriteLine($"Order ID: {order.OrderId} \nUser Id: {order.UserId} \nMedicine ID: {order.MedicineId} \nMedicine Count: {order.MedicineCount} \nTotal Price: {order.TotalPrice} \nOrder Date {order.OrderDate.ToString("dd/MM/yyyy")} \nOrder Status: {order.Status}");
                }
            }
        }
        public static void ShowSubMenu()
        {
            string ans = "yes";
            int option;
            do
            {
                Console.WriteLine("Sub Menu: \n1.Show Medicine List \n2.Purchase Medicine \n3.Cancel Purchase \n4.Show Purchase History \n5.Recharge \n6.Exit");
                option = int.Parse(Console.ReadLine());
                switch(option)
                {
                    case 1:
                    {
                        ShowMedicineList();
                        break;
                    }
                    case 2:
                    {
                        PurchaseMedicine();
                        break;
                    }
                    case 3:
                    {
                        CancelPurchase();
                        break;
                    }
                    case 4:
                    {
                        ShowPurchaseHistory();
                        break;
                    }
                    case 5:
                    {
                        Recharge();
                        break;
                    }
                    case 6:
                    {
                        ans="no";
                        break;
                    }
                }
            }while(ans == "yes");
        }
        public static void ShowMedicineList()
        {
            foreach(MedicineDetails medicine in medicineList)
            {
                Console.WriteLine($"Medicine ID: {medicine.MedicineId} \nMedicine Name: {medicine.MedicineName} \nAvailable Count: {medicine.Count} \nPrice: {medicine.Price} \nDate of Expiry: {medicine.ExpiryDate}");
            }
        }
        public static void PurchaseMedicine()
        {
            ShowMedicineList();
            string ans="yes";
            do
            {
            Console.WriteLine("Select your medicine using Medicine ID:");
            string medicineId = Console.ReadLine();
            Console.WriteLine("Enter the number of count you need:");
            int count = int.Parse(Console.ReadLine());
            foreach(MedicineDetails medicine in medicineList)
            {
                if(medicineId == medicine.MedicineId && count<medicine.Count && currentUser.Balance>=5)
                {
                    double totalPrice = medicine.Price*count;
                    medicine.Count = medicine.Count-count;
                    currentUser.Balance =currentUser.Balance-totalPrice;
                    OrderDetails order = new OrderDetails(currentUser.UserId,medicineId,count,totalPrice,DateTime.Now,Status.Purchased);
                    
                }
            }
            Console.WriteLine("Do you want to order again? (yes/no)");
            ans = Console.ReadLine().ToLower();
            }while(ans=="yes");
        }
        public static void CancelPurchase()
        {
            ShowPurchaseHistory();
            Console.WriteLine("Select the order ID to cancel:");
            string orderId = Console.ReadLine();
            foreach(OrderDetails order in orderList)
            {
                if(orderId == order.OrderId && order.Status==Status.Purchased)
                {
                    foreach(MedicineDetails medicine in medicineList)
                    {
                        if(medicine.MedicineId==order.MedicineId)
                        {
                            medicine.Count = medicine.Count + order.MedicineCount;
                            currentUser.Balance = currentUser.Balance + order.TotalPrice;
                            order.Status=Status.Cancelled;
                            Console.WriteLine($"Order ID: {order.OrderId} was cancelled successfully!");
                        }
                    }
                }
            }
        }
        public static void ShowPurchaseHistory()
        {
            ShowPurchaseHistory();
        }
        public static void Recharge()
        {
            Console.WriteLine($"Your account balance is {currentUser.Balance}");
            Console.WriteLine("Do you want to recharge? (yes/no)");
            string ans = Console.ReadLine();
            if(ans == "yes")
            {
                Console.WriteLine("Enter the amount to be recharged:");
                double price = double.Parse(Console.ReadLine());
                currentUser.Balance=currentUser.Balance+price;
                Console.WriteLine($"Your current balance is {currentUser.Balance}");
            }
        }
        public static void ReadUserDetails()
        {
            StreamReader reader=null;
            if(File.Exists("UserDetails.csv"))
            {
                reader = new StreamReader (File.OpenRead("UserDetails.csv"));
                while(!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var value = line.Split(",");
                    if(value[0]!="" && value[0]!="n")
                    {
                        userList.AddElement(new UserDetails(value[1],int.Parse(value[2]),value[3],long.Parse(value[4]),double.Parse(value[5])));
                    }
                }
            }
            else
            {
                Console.WriteLine("File doesn not exists");
            }
            reader.Close();
        }
        public static void ReadMedicineDetails()
        {
            StreamReader reader=null;
            if(File.Exists("MedicineDetails.csv"))
            {
                reader = new StreamReader (File.OpenRead("MedicineDetails.csv"));
                while(!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var value = line.Split(",");
                    if(value[0]!="" && value[0]!="n")
                    {
                        medicineList.AddElement(new MedicineDetails(value[1]),int.Parse(value[2]),double.Parse(value[3]),DateTime.ParseExact(value[4],"dd/MM/yyyy",null));
                    }
                }
            }
            else
            {
                Console.WriteLine("File doesn not exists");
            }
            reader.Close();
        }
        public static void ReadOrderDetails()
        {
            StreamReader reader=null;
            if(File.Exists("OrderDetails.csv"))
            {
                reader = new StreamReader (File.OpenRead("OrderDetails.csv"));
                while(!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var value = line.Split(",");
                    if(value[0]!="" && value[0]!="n")
                    {
                        orderList.AddElement(new OrderDetails(value[1],value[2],int.Parse(value[3]),double.Parse(value[4]),DateTime.ParseExact(value[5],"dd/MM/yyyy",null),(Status)Enum.Parse(typeof(Status),value[6])));
                    }
                }
            }
            else
            {
                Console.WriteLine("File doesn not exists");
            }
            reader.Close();
        }
        public static void Insert(List<UserDetails> userList)
        {
            StreamWriter writer = null;
            if(File.Exists("UserDetails.csv"))
            {
                writer = new StreamWriter(File.OpenWrite("UserDetails.csv"));
                foreach(UserDetails user in userList)
                {
                    if(user!=null)
                    writer.WriteLine(user.UserId+","+user.UserName+","+user.Age+","+user.City+","+user.PhoneNumber+","+user.Balance);
                }
            }
            else
            {
                Console.WriteLine("File doesn not exists");
            }
            writer.Close();
        }
        public static void Insert(List<MedicineDetails> medicineList)
        {
            StreamWriter writer = null;
            if(File.Exists("MedicineDetails.csv"))
            {
                writer = new StreamWriter(File.OpenWrite("MedicineDetails.csv"));
                foreach(MedicineDetails medicine in medicineList)
                {
                    if(medicine!=null)
                    {
                    writer.WriteLine(medicine.MedicineId+","+medicine.MedicineName+","+medicine.Count+","+medicine.Price+","+medicine.ExpiryDate.ToString("dd/MM/yyyy"));
                    }
                }
            }
            else
            {
                Console.WriteLine("File doesn not exists");
            }
            writer.Close();
        }
        public static void Insert(List<OrderDetails> orderList)
        {
            StreamWriter writer = null;
            if(File.Exists("OrderDetails.csv"))
            {
                writer = new StreamWriter(File.OpenWrite("OrderDetails.csv"));
                foreach(OrderDetails order in orderList)
                {
                    if(order!=null)
                    {
                    writer.WriteLine(order.OrderId+","+order.UserId+","+order.MedicineId+","+order.MedicineCount+","+order.TotalPrice+","+order.OrderDate.ToString("dd/MM/yyyy"));
                    }
                }
            }
            else
            {
                Console.WriteLine("File doesn not exists");
            }
            writer.Close();
        }    
    }

}
   
