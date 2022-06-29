using System;

namespace PayrollManagement
{
    public class WorklogDetails
    {
        public DateTime Date { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public WorklogDetails(DateTime date,DateTime checkIn,DateTime checkOut)
        {
            Date = date;
            CheckIn = checkIn;
            CheckOut=checkOut;
        }
    }
}