using System;
namespace MovieTicketBooking
{   
    public enum Status{Default,Booked,Cancelled}
    public class BookingDetails
    {
        private static int s_bookingId=7000;
        public string BookingId { get; }
        public string UserId { get; set; }
        public string TheatreId { get; set; }
        public string MovieId { get; set; }
        public int Seats { get; set; }
        public double TotalPrice { get; set; }
        public Status Status { get; set; }
        
        public BookingDetails(string userId,string theatreId,string movieId,int seats,double totalPrice,Status status)
        {
            s_bookingId++;
            BookingId="BID"+s_bookingId;
            UserId=userId;
            TheatreId=theatreId;
            MovieId=movieId;
            Seats=seats;
            TotalPrice=totalPrice;
            Status=status;
        }
        
    }
}