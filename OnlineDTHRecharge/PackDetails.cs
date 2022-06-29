namespace OnlineDTHRecharge
{
     /// <summary>
    /// Class <see cref = "PackDetails"/> used to collect recharge pack details
    /// </summary>
    ///
    public class PackDetails
    {
        /// <summary>
        /// Property PackId used to provide Pack ID for the recharge pack in object of <see cref ="PackDetails"/> class
        /// </summary>
        public string PackId { get; set; }
        /// <summary>
        /// Property PackName used to provide Pack Name for the recharge pack in object of <see cref ="PackDetails"/> class
        /// </summary>
        public string PackName { get; set; }
        /// <summary>
        /// Property Price used to provide Pack price for the recharge pack in object of <see cref ="PackDetails"/> class
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Property Validity used to provide number of days of validity for the recharge pack in object of <see cref ="PackDetails"/> class
        /// </summary>
        public int Validity { get; set; }
        /// <summary>
        /// Property Channels used to provide number of channels for the recharge pack in object of <see cref ="PackDetails"/> class
        /// </summary>
        public int Channels { get; set; }
        public PackDetails(string packId,string packName,double price,int validity,int channels)
        {
            PackId=packId;
            PackName=packName;
            Price=price;
            Validity=validity;
            Channels=channels;
        }
        
        
        
        
        
    }
}