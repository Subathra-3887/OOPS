using System;
using System.Collections.Generic;
namespace CafeteriaCard
{
    public class FoodDetails
    {
        
        public static int s_foodId = 100;
        public string FoodId {get; set;}
        public string FoodName { get; set; }
        public double FoodPrice { get; set; }
        public int Quantity { get; set; }
        
        public FoodDetails (string foodName,double foodPrice,int quantity)
        {
            s_foodId++;
            FoodId = "FID"+s_foodId;
            FoodName = foodName;
            FoodPrice = foodPrice;
            Quantity=quantity;           
        }        
        
    }
}