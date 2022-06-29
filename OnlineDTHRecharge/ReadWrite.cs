using System;
using System.IO;
using System.Collections.Generic;

namespace OnlineDTHRecharge
{
    public partial class Operations
    {
        public static void ReadUserDetails()
        {
            StreamReader reader = null;
            if(File.Exists("Data/UserDetails.csv"))
            {
                reader = new StreamReader(File.OpenRead("Data/UserDetails.csv"));
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(",");
                    if(values[0]!="" && values[0]!="n")
                    {
                        userList.AddElement(new UserDetails(values[1],long.Parse(values[2]),values[3],double.Parse(values[4])));
                    }
                }
            }
            else
            {
                Console.WriteLine("File doesnot exists");
            }
            reader.Close();
        }

        public static void ReadPackDetails()
        {
            StreamReader reader = null;
            if(File.Exists("Data/PackDetails.csv"))
            {
                reader = new StreamReader(File.OpenRead("Data/PackDetails.csv"));
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(",");
                    if(values[0]!="" && values[0]!="n")
                    {
                        packList.AddElement(new PackDetails(values[0],values[1],double.Parse(values[2]),int.Parse(values[3]),int.Parse(values[4])));
                    }
                }
            }
            else
            {
                Console.WriteLine("File doesnot exists");
            }
            reader.Close();
        }
        public static void ReadRechargeDetails()
        {
            StreamReader reader = null;
            if(File.Exists("Data/RechargeDetails.csv"))
            {
                reader = new StreamReader(File.OpenRead("Data/RechargeDetails.csv"));
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(",");
                    if(values[0]!="" && values[0]!="n")
                    {
                        rechargeList.AddElement(new RechargeDetails(values[1],values[2],DateTime.ParseExact(values[3],"dd/MM/yyyy",null),DateTime.ParseExact(values[4],"dd/MM/yyyy",null)));
                    }
                }
            }
            else
            {
                Console.WriteLine("File doesnot exists");
            }
            reader.Close();
        }
        public static void Insert(List<UserDetails> userList)
        {
            StreamWriter writer = null;
            if(File.Exists("Data/UserDetails.csv"))
            {
                writer = new StreamWriter (File.OpenWrite("Data/UserDetails.csv"));
                foreach(UserDetails user in userList)
                {
                    if(user!=null)
                    {
                        writer.WriteLine(user.UserId+","+user.UserName+","+user.MobileNumber+","+user.EmailId+","+user.WalletBalance);
                    }
                }
            }
            else
            {
                Console.WriteLine("File does not exists");
            }
            writer.Close();
        }
        public static void Insert(List<PackDetails> packList)
        {
            StreamWriter writer = null;
            if(File.Exists("Data/PackDetails.csv"))
            {
                writer = new StreamWriter (File.OpenWrite("Data/PackDetails.csv"));
                foreach(PackDetails pack in packList)
                {
                    if(pack!=null)
                    {
                        writer.WriteLine(pack.PackId+","+pack.PackName+","+pack.Price+","+pack.Validity+","+pack.Channels);
                    }
                }
            }
            else
            {
                Console.WriteLine("File does not exists");
            }
            writer.Close();
        }
        public static void Insert(List<RechargeDetails> rechargeList)
        {
            StreamWriter writer = null;
            if(File.Exists("Data/RechargeDetails.csv"))
            {
                writer = new StreamWriter (File.OpenWrite("Data/rechargeDetails.csv"));
                foreach(RechargeDetails recharge in rechargeList)
                {
                    if(recharge!=null)
                    {
                        writer.WriteLine(recharge.RechargeId+","+recharge.PackId+","+recharge.UserId+","+recharge.RechargeDate.ToString("dd/MM/yyyy")+","+recharge.ValidTill.ToString("dd/MM/yyyy"));
                    }
                }
            }
            else
            {
                Console.WriteLine("File does not exists");
            }
            writer.Close();
        }
    }
}