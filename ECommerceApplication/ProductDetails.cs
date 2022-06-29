using System;
namespace ECommerceApplication
{
    public class ProductDetails
    {
        private static int s_productId = 100;
        public string ProductId { get; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int Stock { get; set; }
        public int Shippingduration { get; set; }
        
        public ProductDetails(string productName, double productPrice, int stock, int shippingDuration)
        {
            s_productId++;
            ProductId = "PID"+s_productId;
            ProductName = productName;
            ProductPrice = productPrice;
            Stock=stock;
            Shippingduration=shippingDuration;
        }
    }
}