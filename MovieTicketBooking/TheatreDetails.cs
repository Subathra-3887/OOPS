using System.Collections.Generic;

namespace MovieTicketBooking
{
    public class TheatreDetails
    {
        private static int s_theatreId = 300;
        public string TheatreId { get; }
        public string TheatreName { get; set; }
        public List<MovieDetails> MovieList{ get; set; }
        public TheatreDetails(string theatreName,List<MovieDetails> movieList)
        {
            s_theatreId++;
            TheatreId="TID"+s_theatreId;
            TheatreName=theatreName;
            MovieList = movieList;

        }
        
        
    }
}