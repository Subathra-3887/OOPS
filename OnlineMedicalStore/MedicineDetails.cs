using System;
namespace OnlineMedicalStore
{
    public class MedicineDetails
    {
        private static int s_medicineId=100;
        public string MedicineId { get; }
        public string MedicineName { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public DateTime ExpiryDate { get; set; }
        
        public MedicineDetails(string medicineName,int count,double price,DateTime expiryDate)
        {
            s_medicineId++;
            MedicineId="MID"+s_medicineId;
            MedicineName=medicineName;
            Count=count;
            Price=price;
            ExpiryDate=expiryDate;
        }
        
        
        
        
        
    }
}