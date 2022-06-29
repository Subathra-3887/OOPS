using System;
using System.IO;

namespace FilesAndFolders
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\SubathraKaliamoorthy\OneDrive - Syncfusion\Desktop\New folder"; //absolute path

            string folderPath = path+"/My Folder"; //folder inside the path
            string filePath = path+"/newFile.txt"; //text file inside path

            if(!Directory.Exists(folderPath))
            {
                string folder = path+"/My Folder";
                Directory.CreateDirectory(folder);
            }
            else
            {
                Console.WriteLine("Directory already exists");
            }
            if(!File.Exists(filePath))
            {
                string file = path+"/newFile.txt";
                File.Create(file);
            }
            else
            {
                Console.WriteLine("File already exist");
            }
            Console.WriteLine("Select option: \n0.Exit \n1.Create Folder \n2.Create File \n3.Delete Folder \n4.Delete File");
            int num = int.Parse(Console.ReadLine());
            switch(num)
            {
                case 0:
                {
                    break;
                }
                case 1:
                {
                    Console.WriteLine("Enter the name of the folder:");
                    string name1 = Console.ReadLine();
                    string newPath = path+"\\"+name1;
                    if(!Directory.Exists(newPath))
                    {
                        Directory.CreateDirectory(newPath);
                    }
                    else
                    {
                        Console.WriteLine("Directory already exists");
                    }
                    break;
                }
                case 2:
                {
                    Console.WriteLine("Enter the file name to be created:");
                    string name1 = Console.ReadLine();
                    Console.WriteLine("Enter file extensions you want to create:");
                    string ext = Console.ReadLine();
                    string newPath = path +"\\"+name1+"."+ext;
                    if(!File.Exists(newPath))
                    {
                        File.Create(newPath);
                    }
                    else
                    {
                        Console.WriteLine("File already exists");
                    }
                    break;
                }
                case 3:
                {
                    foreach(string name in Directory.GetDirectories(path))
                    {
                        Console.WriteLine(name);
                    }
                    Console.WriteLine("Select the folder to be deleted");
                    string name1 = Console.ReadLine();
                    string newPath = path +"\\"+name1;
                    foreach(string name in Directory.GetDirectories(path))
                    {
                        if(name==newPath)
                        {
                            Directory.Delete(newPath);
                        }
                    }
                    break;
                }
                case 4:
                {
                    foreach(string name in Directory.GetFiles(path))
                    {
                        Console.WriteLine(name);
                    }
                    Console.WriteLine("Select the file to be deleted:");
                    string name1 =Console.ReadLine();
                    Console.WriteLine("Enter the extension of the file to be deleted:");
                    string ext = Console.ReadLine();
                    string newPath= path+"\\"+name1+"."+ext;
                    foreach (string name in Directory.GetFiles(path))
                    {
                        if(name==newPath)
                        {
                            File.Delete(newPath);
                            Console.WriteLine("File has been deleted");
                        }
                    }
                    break;
                }
            }
        }
    }

}
   
