using System;
using System.Collections.Generic;
namespace MovieTicketBooking
{
    class Program
    {   
        static List<UserDetails> userList = new List<UserDetails>();
        static List<MovieDetails> movieList1 =new List<MovieDetails>();
        static List<MovieDetails> movieList2 =new List<MovieDetails>();
        static List<MovieDetails> movieList3 =new List<MovieDetails>();
        static List<TheatreDetails> theatreList = new List<TheatreDetails>();
        static List<BookingDetails> bookingList = new List<BookingDetails>();
        static UserDetails currentUser = null;

        static void Main(string[] args)
        {   
           AddDefaultData();
           ShowMainMenu();
        }
        public static void UserRegistration()
        {
            Console.WriteLine("Enter your Name:");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter your age:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your phone number:");
            long phoneNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Wallet Balance:");
            double walletBalance = double.Parse(Console.ReadLine());
            UserDetails user = new UserDetails(userName,age,phoneNumber,walletBalance);
            userList.Add(user);
            Console.WriteLine("Registered Successfull");
            Console.WriteLine($"User ID: {user.UserId}");
        }
        public static void AddDefaultData()
        {
            UserDetails user = new UserDetails("Ravichandran",30,8599488003,1000);
            userList.Add(user);
            UserDetails user1 = new UserDetails("Baskaran",30,9857747327,2000);
            userList.Add(user1);
         
            //movie default

            MovieDetails movie1 = new MovieDetails("Movie1",5,200);
            movieList1.Add(movie1);
            MovieDetails movie2 = new MovieDetails("Movie2",2,300);
            movieList1.Add(movie2);
            MovieDetails movie3 = new MovieDetails("Movie3",1,50);
            movieList1.Add(movie3);
            
            MovieDetails movie4 = new MovieDetails("Movie4",11,400);
            movieList2.Add(movie4);
            MovieDetails movie5 = new MovieDetails("Movie5",20,300);
            movieList2.Add(movie5);
            MovieDetails movie6 = new MovieDetails("Movie6",2,500);
            movieList2.Add(movie6);
            
            MovieDetails movie7 = new MovieDetails("Movie7",11,100);
            movieList3.Add(movie7);
            MovieDetails movie8 = new MovieDetails("Movie8",20,200);
            movieList3.Add(movie8);
            MovieDetails movie9 = new MovieDetails("Movie9",2,350);
            movieList3.Add(movie9);

            //theatre default

            TheatreDetails theatre1 = new TheatreDetails("Theatre1",movieList1);
            theatreList.Add(theatre1);
            TheatreDetails theatre2 = new TheatreDetails("Theatre2",movieList2);
            theatreList.Add(theatre2);
            TheatreDetails theatre3 = new TheatreDetails("Theatre3",movieList3);
            theatreList.Add(theatre3);

            //booking default

            BookingDetails booking1 = new BookingDetails("UID1001","TID303","MID501",1,200,Status.Booked);
            bookingList.Add(booking1);
            BookingDetails booking2 = new BookingDetails("UID1001","TID302","MID504",1,400,Status.Booked);
            bookingList.Add(booking2);
            BookingDetails booking3 = new BookingDetails("UID1002","TID302","MID505",1,300,Status.Booked);
            bookingList.Add(booking3);
        }
        public static void ShowMainMenu()
        {
             string ans="yes";
            int option;
            do
            {
                Console.WriteLine("Main Menu: \n1.User Regidtration \n2.Login \n3.Exit");
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
                        Login();
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
        public static void Login()
        {
            Console.WriteLine("Enter your user ID:");
            string userId = Console.ReadLine().ToUpper();
            foreach(UserDetails user in userList)
            {
                if(userId==user.UserId)
                {
                    Console.WriteLine("Login Successfull");
                    currentUser = user;
                    ShowSubMenu();
                }
            }
        }
        public static void ShowSubMenu()
        {   string ans="yes";
            do
             {
                Console.WriteLine("Sub Menu: \n1.Ticket Booking \n2.Ticket Cancellation \n3.Booking History \n4.Wallet Recharge \n5.Exit");
                int option = int.Parse(Console.ReadLine());
                switch(option)
                {
                    case 1:
                    {
                        TicketBooking();
                        break;
                    }
                    case 2:
                    {
                        TicketCancellation();
                        break;
                    }
                    case 3:
                    {
                        BookingHistory();
                        break;
                    }
                    case 4:
                    {
                        WalletRecharge();
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
        public static void TicketBooking()
        {
            foreach(TheatreDetails theatreValue in theatreList)
            {   
                Console.WriteLine($"Theatre Id: {theatreValue.TheatreId}");
                Console.WriteLine($"Theatre Name: {theatreValue.TheatreName}");
                Console.WriteLine();
            }
            Console.WriteLine("Select your theatre using theatre ID:");
            string theatreId = Console.ReadLine().ToUpper();
            foreach(TheatreDetails theatre in theatreList)
            {
                if(theatreId == theatre.TheatreId)
                {
                    foreach(MovieDetails movies in theatre.MovieList)
                    {
                        Console.WriteLine($"Movie ID: {movies.MovieId} \nMovie Name: {movies.MovieName} \nNumber Of Seats: {movies.Seats} \nTicket Price: {movies.Price}");
                        Console.WriteLine();
                    }
                    Console.WriteLine("Select your movie using movie ID:");
                    string movieId = Console.ReadLine().ToUpper();
                    foreach (MovieDetails movie in theatre.MovieList)
                    {
                        if(movieId == movie.MovieId)
                        {
                            Console.WriteLine("Enter the number of seats:");
                            int seats = int.Parse(Console.ReadLine());
                            if(seats<movie.Seats)
                            {
                                double totalPrice = seats*movie.Price;
                                if(totalPrice<currentUser.WalletBalance)
                                {
                                    currentUser.WalletBalance = currentUser.WalletBalance- totalPrice;
                                    movie.Seats = movie.Seats-seats;
                                    BookingDetails booking = new BookingDetails(currentUser.UserId,theatreId,movieId,seats,totalPrice,Status.Booked);
                                    bookingList.Add(booking);
                                    Console.WriteLine("Ticket Booked Successfully");
                                    Console.WriteLine($"Booking ID: {booking.BookingId}");
                                }
                                else
                                {
                                    Console.WriteLine("Insuffecient Balance! Please recharge your wallet");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Seats not available");
                            }
                        }
                    }
                }
            }
        }
        public static void TicketCancellation()
        {
           BookingHistory();
           Console.WriteLine("Select the booking Id that is to be cancelled:");
           string bookingId = Console.ReadLine().ToUpper();
           foreach(BookingDetails booking in bookingList)
           {
               if(bookingId == booking.BookingId && booking.Status==Status.Booked)
               {
                   foreach (TheatreDetails theatre in theatreList)
                   {
                       if(booking.TheatreId==theatre.TheatreId)
                       {
                           foreach(MovieDetails movie in theatre.MovieList)
                           {
                               if (movie.MovieId==booking.MovieId)
                               {
                                   movie.Seats= movie.Seats-booking.Seats;
                                   currentUser.WalletBalance=currentUser.WalletBalance+booking.TotalPrice;
                                   booking.Status=Status.Cancelled;
                                   Console.WriteLine("Your booking has been cancelled");
                               }
                           }
                       }
                   }
               }
           }
        }
        public static void BookingHistory()
        {
            foreach(BookingDetails booking in bookingList)
            {
                if(booking.UserId==currentUser.UserId)
                {
                Console.WriteLine($"Booking ID: {booking.BookingId} \nUser ID: {booking.UserId} \nMovie ID: {booking.MovieId} \nTheatre ID: {booking.TheatreId} \nSeats Count: {booking.Seats} \nTotal Price: {booking.TotalPrice} \nBooking Status: {booking.Status}");
                }
                Console.WriteLine();
            }
        }
        public static void WalletRecharge()
        {
            Console.WriteLine($"Your current balance is: {currentUser.WalletBalance}");
            Console.WriteLine("Do you want to recharge your wallet balance?");
            string ans = Console.ReadLine();
            if(ans == "yes")
            {
                Console.WriteLine("Enter the amount to be recharged in your wallet:");
                double price = double.Parse(Console.ReadLine());
                currentUser.WalletBalance=currentUser.WalletBalance+price;
                Console.WriteLine($"Your current balance is: {currentUser.WalletBalance}");
            }
        }
    }

}
   
