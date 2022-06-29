using System;
using System.Collections.Generic;

namespace CafeteriaCard
{
    class Program
    {
        static List<UserRegistration> userList = new List<UserRegistration>();
        static List<FoodDetails> foodList = new List<FoodDetails>();
        static List<OrderItem> orderList = new List<OrderItem>();
        static UserRegistration currentUser = null;
        static void Main(string[] args)
        {
            UserDefault();
            FoodDefault();
            int option;
            do
            {
                Console.WriteLine("Menu: \n1.User Registration \n2.User Login \n3.Exit");
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

                }   
            }while(option!=3);
                
        }
    public static void Registration()
    {
        Console.WriteLine("Enter your name:");
        string userName =Console.ReadLine(); 
        Console.WriteLine("Enter your mobile number:");
        long mobileNumber = long.Parse(Console.ReadLine());
        Console.WriteLine("Enter your workstation number(WS101):");
        string workStation = Console.ReadLine().ToUpper();
        Console.WriteLine("Enter your balance:");
        double balance = double.Parse(Console.ReadLine());
        UserRegistration user = new UserRegistration(userName,mobileNumber,workStation,balance);
        userList.Add(user);
        Console.WriteLine($"User ID: {user.UserId}");    
    }
    static void UserDefault()
    {
        UserRegistration user = new UserRegistration("Ravichandran",8857777575 ,"WS101",400);
        userList.Add(user);
        UserRegistration user1 = new UserRegistration("Baskaran",9577747744 ,"WS105",500);
        userList.Add(user1);
    }
    static void FoodDefault()
    {
        FoodDetails food1 = new FoodDetails("Coffee",20,1000);
        foodList.Add(food1);
        FoodDetails food2 = new FoodDetails("Tea",15,1000);
        foodList.Add(food2);
        FoodDetails food3 = new FoodDetails("Biscuit",10,1000);
        foodList.Add(food3);
        FoodDetails food4 = new FoodDetails("Juice",50,1000);
        foodList.Add(food4);
        FoodDetails food5 = new FoodDetails("Puff",40,1000);
        foodList.Add(food5);
    } 
    public static void FoodOrder()
    {
        double foodPrice=0;
        string ans = null;
        do
        {
        Console.WriteLine("The Menu are as follows:");
        Console.WriteLine("Food Id \tFood Name \tFoodPrice \tAvailable Quanitiy");
        foreach (FoodDetails food in foodList)
        {
            Console.WriteLine($"{food.FoodId} \t\t{food.FoodName} \t\t{food.FoodPrice} \t\t{food.Quantity}");
        }
        Console.WriteLine("Enter the food ID:");
        string foodId = Console.ReadLine();
        Console.WriteLine("Enter the required quantity:");
        int quantity = int.Parse(Console.ReadLine());
        foreach(FoodDetails food in foodList)
        {
            if(foodId == food.FoodId)
            {
               food.Quantity = food.Quantity-quantity;
               foodPrice = foodPrice + quantity*food.FoodPrice;
               food.Quantity = quantity;
               OrderItem order1 = new OrderItem(food.FoodId,food.FoodName,food.FoodPrice,food.Quantity);
               orderList.Add(order1);
               
            }
        }
        Console.WriteLine("Do you want to add items(yes/no):");
        ans = Console.ReadLine().ToLower();
        }while(ans=="yes");
       
        
    }
    public static void OrderHistory()
    {
        Console.WriteLine("Enter your order Id:");
        string orderId = Console.ReadLine();
        Console.WriteLine("Enter your UserID:");
        string userId = Console.ReadLine();
        Console.WriteLine("Enter the order Date:");
        DateTime orderDate = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
        
    }
    public static void Login()
    {
        Console.WriteLine("Enter your User ID:");
        string userId = Console.ReadLine();
        foreach(UserRegistration user in userList)
        {
            if(userId == user.UserId)
            {
                Console.WriteLine("Login Successfull");
                currentUser = user;
                SubMenu();
            }
        }
    }
    public static void SubMenu()
    {
        int option;
        do
        {
            Console.WriteLine("SubMenu: \n1.Food Order \n2.View Food Order Details \n3.Recharge \n4.Exit");
            option = int.Parse(Console.ReadLine());
            switch(option)
            {
                case 1:
                {
                    FoodOrder();
                    break;
                }
                case 2:
                {
                    OrderHistory();
                    break;
                }
                case 3:
                {
                    currentUser.Recharge();
                    break;
                }
            }   
        }while(option!=4);
     }
    }

}
   
