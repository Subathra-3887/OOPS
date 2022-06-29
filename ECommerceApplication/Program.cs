using System;
using System.Collections.Generic;
namespace ECommerceApplication
{
    class Program
    {
        static List<CustomerDetails> customerList = new List<CustomerDetails>();
        static List<ProductDetails> productList = new List<ProductDetails>();
        static List<OrderDetails> orderList = new List<OrderDetails>();
        static CustomerDetails currentUser = null;
        static OrderDetails cancelProduct = null;
        static void Main(string[] args)
        {
            CustomerDefault();
            ProductDefault();
            OrderDefault();

            int option;
            do
            {
                Console.WriteLine("Select from Main Menu: \n1.Customer Registration \n2.Login and Purchase \n3.Exit");
                option = int.Parse(Console.ReadLine());
                switch(option)
                {
                    case 1:
                    {
                        Registration();
                        break;
                    }
                    case 2 :
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
            string customerName = Console.ReadLine();
            Console.WriteLine("Enter your city");
            string city = Console.ReadLine();
            Console.WriteLine("Enter your Mobile Number:");
            long mobileNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter your wallet balance:");
            double walletBalance = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter your email ID:");
            string emailId = Console.ReadLine();

            CustomerDetails customer = new CustomerDetails(customerName,city,mobileNumber,walletBalance,emailId);
            customerList.Add(customer);
            Console.WriteLine($"Customer ID: {customer.CustomerId}");
        }
        static void CustomerDefault()
        {
            CustomerDetails customer1 = new CustomerDetails("Ravi","Chennai",9885858588,50000,"ravi@mail.com");
            customerList.Add(customer1);
            CustomerDetails customer2 = new CustomerDetails("Baskaran","Chennai",9888475757,60000,"baskaran@mail.com");
            customerList.Add(customer2); 
        }

        static void ProductDefault()
        {
            ProductDetails product1 = new ProductDetails("Mobile",10000,10,3);
            productList.Add(product1);
            ProductDetails product2 = new ProductDetails("Tablet",15000,5,2);
            productList.Add(product2);
            ProductDetails product3 = new ProductDetails("Camera",20000,3,4);
            productList.Add(product3);
            ProductDetails product4 = new ProductDetails("iPhone",50000,5,6);
            productList.Add(product4);
            ProductDetails product5 = new ProductDetails("Laptop",40000,3,3);
            productList.Add(product5);
        }
        static void OrderDefault()
        {
            OrderDetails order1 = new OrderDetails ("CID1001","PID101",20000,DateTime.Today,2,OrderStatus.Ordered);
            orderList.Add(order1);
            OrderDetails order2 = new OrderDetails ("CID1002","PID103",40000,DateTime.Today,2,OrderStatus.Ordered);
            orderList.Add(order2);
        }
        public static void WalletBalance()
        {
            Console.WriteLine($"Your current balance is: {currentUser.WalletBalance}");
            Console.WriteLine("Do you want to recharge your wallet(yes/no):");
            string answer = Console.ReadLine().ToLower();
            if(answer=="yes")
            {
                Console.WriteLine("Enter the amount to be recharged:");
                double amount = double.Parse(Console.ReadLine());
                currentUser.WalletBalance = currentUser.WalletBalance+amount;
                Console.WriteLine($"Your updated wallet balance is: {currentUser.WalletBalance}");
            }
        }
        public static void ProductList()
        {
            Console.WriteLine("Product ID \tProductName \tPrice Per Quantity \tAvailable Stock Quantity \tShipping Duration");
            foreach(ProductDetails product in productList)
            {
                Console.WriteLine($"{product.ProductId} \t\t{product.ProductName} \t\t {product.ProductPrice} \t\t\t{product.Stock} \t\t\t\t{product.Shippingduration}");
            }
        }
        public static void Purchase()
        {
            DateTime deliveryDate;
            double totalPrice=0;
            Console.WriteLine("Enter the Product ID:");
            string productId = Console.ReadLine().ToUpper();
            Console.WriteLine("Enter the quantity to be purchased");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the purchase date:");
            DateTime purchaseDate = DateTime.Now;
            foreach(ProductDetails product in productList)
            {
                if(productId == product.ProductId )
                {
                    if(quantity>product.Stock)
                    {
                        Console.WriteLine("Required Count Not Available");
                    }
                    else
                    {
                        totalPrice = (quantity*product.ProductPrice)+500.0;
                        if(totalPrice>currentUser.WalletBalance)
                        {
                            Console.WriteLine("Insuffecient Wallet Balance! Please recharge your wallet");
                        }
                        else
                        {
                            currentUser.WalletBalance = currentUser.WalletBalance-totalPrice;
                            product.Stock = product.Stock-quantity;
                            deliveryDate = purchaseDate.AddDays(product.Shippingduration);
                            Console.WriteLine($"Order placed successfully! Your order will be delivered on {deliveryDate.ToString("dd/MM/yyyy")}");
                        }
                    }
                }   
            } 
            OrderDetails order = new OrderDetails(currentUser.CustomerId,productId,totalPrice,purchaseDate,quantity,OrderStatus.Ordered);
            orderList.Add(order);
        }
        public static void OrderHistory()
        {
            Console.WriteLine("OrderID \tCustomer ID \tProduct ID \tTotalPrice \tPurchaseDate \t\tQuanitity \t\tOrderStatus");
        
            foreach(OrderDetails order in orderList)
            {
                if(order.CustomerId==currentUser.CustomerId){
                Console.WriteLine($"{order.OrderId} \t{order.CustomerId} \t{order.ProductId} \t\t{order.TotalPrice} \t\t{order.PurchaseDate} \t\t{order.Quantity} \t\t{order.OrderStatus}");
                }
            }
        }
        public static void CancelOrder()
        {
            string cancelId = "";
            Console.WriteLine("Enter the order ID to be cancelled:");
            string orderId = Console.ReadLine().ToUpper();
            foreach(OrderDetails order in orderList)
            {
                if(orderId == order.OrderId)
                {
                    cancelProduct = order;
                    currentUser.WalletBalance = currentUser.WalletBalance+order.TotalPrice;
                    order.OrderStatus = OrderStatus.Cancelled;
                }
            }
            foreach(ProductDetails product in productList)
            {
                if(cancelId==product.ProductId)
                {
                    product.Stock=product.Stock+ cancelProduct.Quantity;
                    Console.WriteLine("Order cancelled successfully!");
                }
            }

        }
        public static void Login()
        {
            Console.WriteLine("Enter your CustomerID");
            string customerId = Console.ReadLine().ToUpper();
            foreach(CustomerDetails customer in customerList)
            {
            if(customerId == customer.CustomerId)
            {
                Console.WriteLine("Login successfull");
                currentUser = customer;
                SubMenu();
            }
            else
            {
                Console.WriteLine("Invalid Customer ID");
            }
            }
        }
        public static void SubMenu()
        {
            char option;
            do
            {
                Console.WriteLine("SubMenu: \na.Purchase \nb.Order History \nc.Cancel Order \nd.Wallet Balance \ne.Exit");
                option = char.Parse(Console.ReadLine().ToLower());
                switch(option)
                {
                    case 'a':
                    {
                        ProductList();
                        Purchase();
                        break;
                    }
                    case 'b':
                    {
                        OrderHistory();
                        break;
                    }
                    case 'c':
                    {
                        OrderHistory();
                        CancelOrder();
                        break;
                    }
                    case 'd':
                    {
                        WalletBalance();
                        break;
                    }
                }
            }while(option!='e');
        }
    }

}
   
