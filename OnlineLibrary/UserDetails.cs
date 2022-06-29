namespace OnlineLibrary
{
    public enum Department {Default,ECE,EEE,CSE}
    public class UserDetails
    {
        private static int s_registrationId =3000;
        public string  RegistrationId { get; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public Department Department { get; set; }     
        public long MobileNumber  { get; set; }   
        public string MailId { get; set; }
        

        public UserDetails (string userName, string gender, Department department, long mobileNumber, string mailId)
    {
        s_registrationId++;
        RegistrationId = "SF"+s_registrationId;
        UserName=userName;
        Gender=gender;
        MobileNumber=mobileNumber;
        MailId=mailId;
    }
    
    }
}