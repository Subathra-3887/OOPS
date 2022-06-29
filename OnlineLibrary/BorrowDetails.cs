using System;
namespace OnlineLibrary
{
    public class BorrowDetails
    {
        private static int s_borrowId =3000;
        public string  BorrowkId { get; }
        public string BookId { get; set; }
        public string RegistrationId { get; set; } 
        public DateTime BorrowedDate { get; set; }
        

        public BorrowDetails (string bookId, string registerId, DateTime borrowedDate)
    {
        s_borrowId++;
        BorrowkId = "LB"+s_borrowId;
        BookId = bookId;
        RegistrationId=registerId;
        BorrowedDate=borrowedDate;
    }
    
    }
}