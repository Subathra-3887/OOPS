using System;
using System.Collections.Generic;

namespace OnlineLibrary
{
    class Program
    {
        static List<UserDetails> userList = new List<UserDetails>();
        static List<BookDetails> bookList = new List<BookDetails>();
        static List<BorrowDetails>borrowList = new List<BorrowDetails>();
        static UserDetails currentUser = null;

        static void Main(string[] args)
        {
            AddDefault();
             string ans="yes";
            int option;
            do
            {
                Console.WriteLine("Main Menu: \n1.User Registration \n2.User Login \n3.Admin Login \n4.Exit");
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
                        AdminLogin();
                        break;
                    }
                case 4:
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
            Console.WriteLine("Enter your gender:");
            string gender = Console.ReadLine();
            Console.WriteLine("Select your Department \n1.ECE \n2.EEE \n3.CSC");
            int departValue = int.Parse(Console.ReadLine());
            Department department = (Department)departValue;
            Console.WriteLine("Enter your Mobile Number:");
            long mobileNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter your mail ID: ");
            string mailId = Console.ReadLine();
            UserDetails user = new UserDetails(userName,gender,department,mobileNumber,mailId);
            userList.Add(user);
            Console.WriteLine($"Registration ID: {user.RegistrationId}");
        }
        public static void UserLogin ()
        {
            Console.WriteLine("Enter your user ID:");
            string userId = Console.ReadLine().ToUpper();
            foreach(UserDetails user in userList)
            {
                if(userId==user.RegistrationId)
                {
                    Console.WriteLine("Login Successfull");
                    currentUser = user;
                    ShowSubMenu();
                }
            }
        }
        public static void AdminLogin()
        {
            Console.WriteLine("Enter your ID:");
            string adminId = Console.ReadLine().ToLower();
            if(adminId == "admin123")
            {   
                string ans="yes";
            do
            {
                 Console.WriteLine("Sub Menu: \n1.Return Books \n2.Renew Books \n3.Exit");
            int option = int.Parse(Console.ReadLine());
            switch(option)
            {
                case 1:
                {
                    ReturnBooks();
                    break;
                }
                case 2:
                {
                    RenewBook();
                    break;
                }
                case 3:
                {   
                    ans = "no";
                    break;
                }
            }
            }while(ans=="yes");
            }
        }
        public static void ShowSubMenu()
        {
            string ans="yes";
            do
            {
                 Console.WriteLine("Sub Menu: \n1.Borrow Books \n2.Show Return Date \n3.Show borrowed History \n4.Return Books \n5.Exit");
            int option = int.Parse(Console.ReadLine());
            switch(option)
            {
                case 1:
                {
                    BorrowBooks();
                    break;
                }
                case 2:
                {
                    ShowReturnDate();
                    break;
                }
                case 3:
                {
                    ShowBorrowedHistory();
                    break;
                }
                case 4:
                {
                    ReturnBooks();
                    break;
                }
                case 5:
                {   
                    ans = "no";
                    break;
                }
            }
            }while(ans=="yes");
        }
        public static void BorrowBooks()
        {
            int count=0;
            foreach(BookDetails books in bookList)
            {
                Console.WriteLine($"Book ID: {books.BookId} \nBook Name: {books.BookName} \nAuthour Name: {books.AuthorName} \nBook Count: {books.BookCount}");
            }
            Console.WriteLine("Enter the Book ID to borrow:");
            string bookId = Console.ReadLine().ToUpper();
            foreach(BookDetails book in bookList)
            {   
                if (bookId == book.BookId)
                {
                    if (book.BookCount>0)
                    {
                        foreach(BorrowDetails borrow in borrowList)
                        {
                            if(borrow.RegistrationId==currentUser.RegistrationId){
                            count++;
                            }
                        }
                        if(count<3)
                        {
                            BorrowDetails borrow = new BorrowDetails(bookId,currentUser.RegistrationId,DateTime.Today);
                            borrowList.Add(borrow);
                            Console.WriteLine("Book borrowed successfully");
                        }
                    }
                    else 
                    {
                        Console.WriteLine("Books are not available for the selected count");
                        foreach(BorrowDetails borrow in borrowList)
                        {
                            if(bookId==borrow.BookId)
                            {
                                DateTime date = borrow.BorrowedDate.AddDays(15);
                                Console.WriteLine($"The book will be available on {date.ToString("dd/MM/yyyy")}");
                            }
                        }
                    }
                }
            }    
        }
        public static void ShowReturnDate()
        {
            foreach(BorrowDetails borrow in borrowList)
            {
                if(borrow.RegistrationId == currentUser.RegistrationId)
                {
                    DateTime date = DateTime.Today;
                    if(date<borrow.BorrowedDate.AddDays(15))
                    {
                        Console.WriteLine($"Return Date for {borrow.BookId}: {borrow.BorrowedDate.AddDays(15)}");
                    }
                    else
                    {
                        TimeSpan days = date-borrow.BorrowedDate.AddDays(15);
                        int totalDays = int.Parse(days.Days.ToString());
                        Console.WriteLine($"The fine amount for {borrow.BookId} is {totalDays*1}");
                    }
                }
            }
        }
        public static void ShowBorrowedHistory()
        {
            foreach(BorrowDetails borrow in borrowList)
            {
                if(borrow.RegistrationId == currentUser.RegistrationId)
                {
                Console.WriteLine($"Borrow ID: {borrow.BorrowkId} \nBook ID: {borrow.BookId} \nRegister ID: {borrow.RegistrationId} \nBorrowed Date: {borrow.BorrowedDate.ToString("dd/MM/yyyy")}");
                }
            }
        }
        public static void ReturnBooks()
        {
            ShowBorrowedHistory();
            Console.WriteLine("Enter your borrow ID:");
            string borrowId = Console.ReadLine();
            Console.WriteLine("Enter your registration ID:");
            string registerId = Console.ReadLine();
            foreach(BorrowDetails borrow in borrowList)
            {
                if(borrowId==borrow.BorrowkId && registerId==borrow.RegistrationId)
                {
                    DateTime date = DateTime.Today;
                    if(date>borrow.BorrowedDate.AddDays(15))
                    {
                        TimeSpan days = date-borrow.BorrowedDate.AddDays(15);
                        int totalDays = int.Parse(days.Days.ToString());
                        int totalAmount = totalDays*1;
                        Console.WriteLine($"The fine amount for {borrow.BookId} is {totalAmount} \nPlease pay:");
                        int amount = int.Parse(Console.ReadLine());
                        if (amount == totalAmount)
                        {
                            borrowList.RemoveAll(borrow=>borrow.BorrowkId == borrowId );
                        }
                    }
                    else
                    {
                        Console.WriteLine("Your book has been returned");
                        borrowList.RemoveAll(borrow=>borrow.BorrowkId == borrowId);
                    }
                }
            }

        }
        public static void RenewBook()
        {
            ShowBorrowedHistory();
            Console.WriteLine("Enter your borrow ID:");
            string borrowId = Console.ReadLine();
            Console.WriteLine("Enter your registration ID:");
            string registerId = Console.ReadLine();
            foreach(BorrowDetails borrow in borrowList)
            {
                if(borrowId==borrow.BorrowkId && registerId==borrow.RegistrationId)
                {
                    DateTime date = DateTime.Today;
                    if(date>borrow.BorrowedDate.AddDays(15))
                    {
                        TimeSpan days = date-borrow.BorrowedDate.AddDays(15);
                        int totalDays = int.Parse(days.Days.ToString());
                        int totalAmount = totalDays*1;
                        Console.WriteLine($"The fine amount for {borrow.BookId} is {totalAmount} \nPlease pay:");
                        int amount = int.Parse(Console.ReadLine());
                        if (amount == totalAmount)
                        {
                            borrowList.RemoveAll(borrow=>borrow.BorrowkId == borrowId && borrow.RegistrationId ==registerId );
                        }
                    }
                }
            }
        }
        public static void AddDefault()
        {
            UserDetails user1 = new UserDetails("Ravi","Male",Department.EEE,9876543234,"ravi@gmail.com");
            userList.Add(user1);
            UserDetails user2 = new UserDetails("Baskaran","Male",Department.CSE,9876543234,"baskaran@gmail.com");
            userList.Add(user2);  

            BookDetails book1 = new BookDetails("C#","Author1",3);
            bookList.Add(book1);
            BookDetails book2 = new BookDetails("HTML","Author2",5);
            bookList.Add(book2);
            BookDetails book3 = new BookDetails("CSS","Author3",3);
            bookList.Add(book3);
            BookDetails book4 = new BookDetails("JS","Author4",3);
            bookList.Add(book4);
            BookDetails book5 = new BookDetails("TS","Author5",2);
            bookList.Add(book5);

            BorrowDetails borrow1 = new BorrowDetails("BID101","SF3001", new DateTime(2022,4,10));
            borrowList.Add(borrow1);
            BorrowDetails borrow2 = new BorrowDetails("BID103","SF3001", new DateTime(2022,4,12));
            borrowList.Add(borrow2);
            BorrowDetails borrow3 = new BorrowDetails("BID104","SF3001", new DateTime(2022,4,15));
            borrowList.Add(borrow3);
            BorrowDetails borrow4 = new BorrowDetails("BID102","SF3002", new DateTime(2022,04,11));
            borrowList.Add(borrow4);
            BorrowDetails borrow5 = new BorrowDetails("BID105","SF3002", new DateTime(2022,04,15));
            borrowList.Add(borrow5);
        }
    }

}
   
