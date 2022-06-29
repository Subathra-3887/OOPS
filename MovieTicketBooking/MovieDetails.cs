namespace MovieTicketBooking
{
    public class MovieDetails
    {
        private static int s_movieId = 500;
        public string MovieId { get; }
        public string MovieName { get; set; }
        public int Seats { get; set; }
        public double Price { get; set; }
        
        public MovieDetails(string movieName,int seats,double price)
        {
            s_movieId++;
            MovieId="MID"+s_movieId;
            MovieName=movieName;
            Seats=seats;
            Price=price;
        }
        
        
        
        
        
    }
}