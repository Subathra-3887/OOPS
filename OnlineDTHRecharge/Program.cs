using System;

namespace OnlineDTHRecharge
{
    class Program
    {
        static void Main(string[] args)
        {
            Operations.ReadUserDetails();
            Operations.ReadPackDetails();
            Operations.ReadRechargeDetails();

            Operations.ShowMainMenu();
            
            Operations.Insert(Operations.userList);
            Operations.Insert(Operations.packList);
            Operations.Insert(Operations.rechargeList);
        }
    }

}
   
