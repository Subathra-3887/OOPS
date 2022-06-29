namespace JobApply
{
    public class RecruiterDetails
    {
        private static int s_recId = 2000;
        public string RecId { get; set; }
        public string RecName { get; set; }
        public string Position { get; set; }
        public string CompanyName { get; set; }
        public string Role { get; set; }
        
        
        public RecruiterDetails(string recName,string position,string companyName,string role)
        {
            s_recId++;
            RecId="RID"+s_recId;
            RecName=recName;
            Position=position;
            CompanyName=companyName;
            Role=role;
        }
    }
}