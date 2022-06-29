namespace CafeteriaCard
{
    public class OrderItem
    {
        public static int s_orderId = 1000;
        public string OrderId {get; set;}
        public string FoodId { get; set; }
        public string FoodName { get; set; }
        public double FoodPrice { get; set; }
        public int Ordercount { get; set; }
        
        public OrderItem(string foodId, string foodName,double foodPrice,int orderCount)
        {
            FoodId=foodId;
            FoodName=foodName;
            FoodPrice = foodPrice;
            Ordercount=orderCount;
        }
    }
}