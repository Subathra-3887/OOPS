using System;
using System.Collections.Generic;

namespace CafeteriaCard
{
    public class OrderDetails
    {
        public static int s_orderId = 1000;
        public string OrderId { get; set; }
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetails> OrderList { get; set; }
        public double OrderPrice { get; set; }
        
        public  OrderDetails(string orderId,string userId,DateTime orderDate,List<OrderDetails>orderList,double orderPrice)
        {   
            s_orderId++;
            OrderId="OID"+s_orderId;
            UserId = userId;
            OrderDate = orderDate;
            List<OrderDetails>OrderList = orderList;
            OrderPrice = orderPrice;

        }
        
        
        
        
        
                
    }
}