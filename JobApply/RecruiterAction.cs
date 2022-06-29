namespace JobApply
{
    public class RecruiterAction
    {
        public string RecId { get; set; }
        public string UserId { get; set; }
        public string Position { get; set; }
        public string CompanyName { get; set; }
        public string Action { get; set; }
        
        public RecruiterAction(string recId,string userId,string position,string companyName,string action)
        {
            RecId=recId;
            UserId=userId;
            Position = position;
            CompanyName=companyName;
            Action=action;
        }
        
        
        
        
        
    }
}