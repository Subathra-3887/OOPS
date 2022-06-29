using System;
using System.Collections.Generic;
using System.IO;

namespace ListFileManipulation
{
        class Program
    {
        static void Main(string[] args)
        {
            List<StudentInfo> vlist = new List<StudentInfo>();
            vlist.Add(new StudentInfo(){Name="Suba",FatherName="Kaliamoorthy"});
            vlist.Add(new StudentInfo(){Name="Usha",FatherName="Moorthy"});
            vlist.Add(new StudentInfo(){Name="Suguna",FatherName="Natarajan"});
            Insert(vlist);
           // Display();
            Update();
        }
        static void Insert(List<StudentInfo> vlist)
        {
            StreamWriter write = null;
            if(!File.Exists("Data.csv"))
            {
                File.Create("Data.csv");
            }
            else
            {
                write = new StreamWriter(File.OpenWrite("Data.csv"));
                foreach(var v in vlist)
                {
                    write.WriteLine(v.Name+","+v.FatherName);
                }
                write.WriteLine();
            }
            write.Close();
        }
        static void Display()
        {
            StreamReader reader = null;
            List<StudentInfo> listA = new List<StudentInfo>();
            if(!File.Exists("Data.csv"))
            {
                reader = new StreamReader(File.OpenRead("Data.csv"));
                while(!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if(values[0]!="" && values[0]!="n")
                    {
                        listA.Add(new StudentInfo(){Name=values[0],FatherName=values[1]});
                    }
                }
            }
            else
            {
                Console.WriteLine("File doesn't exist");
            }
            reader.Close();
            foreach(var column1 in listA)
            {
                Console.WriteLine($"Your Name: {column1.Name} \tFather Name: {column1.FatherName}");
            }  
        }
        static void Update()
        {
            Console.WriteLine("To update select: \n0:Your name  \n1.Father name");
            int option = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter name to be updated");
            string name = Console.ReadLine();

            string[]lines = File.ReadAllLines("Data.csv");
            for(int i =0;i<lines.Length;i++)
            {
                if(lines[i]!="")
                {
                    var values = lines[i].Split(",");
                    if(values[option]==name)
                    {
                        Console.WriteLine("Enter the new name to be updated:");
                        string name1 = Console.ReadLine();
                        if(option==0)
                        {
                            lines[i]= name1 +","+values[1];
                        }
                        else if(option==1)
                        {
                            lines[i] = values[0]+","+name1;
                        }
                    }
                }
            }
            File.WriteAllLines("Data.csv",lines);
        }
    }
}
   
