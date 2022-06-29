using System;
namespace OnlineDTHRecharge
{
     /// <summary>
    /// Class <see cref = "RechargeDetails"/> used to collect recharge history details
    /// </summary>
    ///
    public class RechargeDetails
    {
        /// <summary>
        /// Static field used to auto increment and it uniqely idetifies of <see cref = "RechargeDetails"/> class
        /// </summary>
        private static int s_rechargeId =100;
        /// <summary>
        /// Property RechargeId used to provide Recharge ID for the recharge pack in object of <see cref ="RechargeDetails"/> class
        /// </summary>
        public string RechargeId { get; set; }
        /// <summary>
        /// Property Pack ID used to provide Pack ID for the recharge pack in object of <see cref ="RechargeDetails"/> class
        /// </summary>
        public string PackId { get; set; }
        /// <summary>
        /// Property UserId used to provide User ID for the recharge pack in object of <see cref ="RechargeDetails"/> class
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// Property RechargeDate used to provide recharge date for the recharge pack in object of <see cref ="RechargeDetails"/> class
        /// </summary>
        public DateTime RechargeDate { get; set; }
        /// <summary>
        /// Property ValidTill used to provide end date for the recharge pack in object of <see cref ="RechargeDetails"/> class
        /// </summary>
        public DateTime ValidTill { get; set; }
        public RechargeDetails(string packId,string userId,DateTime rechargeDate,DateTime validTill)
        {
            s_rechargeId++;
            RechargeId="RP"+s_rechargeId;
            PackId=packId;
            UserId=userId;
            RechargeDate=rechargeDate;
            ValidTill=validTill;            
        }
    }
}