using System;
using System.IO;

namespace ReadWriteTextFile
{
    class Program
    {
        static void Main(string[] args)
        {
            if(!Directory.Exists("TestFolder"))
            {
                Directory.CreateDirectory("TestFolder");
                Console.WriteLine("Folder created");
            }
            else
            {
                Console.WriteLine("Folder exits");
                if(!File.Exists("TestFolder/Test.txt"))
                {
                    File.Create("TestFolder/Test.txt");
                    Console.WriteLine("File created");
                }
                else
                {
                    Console.WriteLine("File already exists");
                }
            }
            Console.WriteLine("Select your option: \n1.Read file \n2.Write file");
            int option = int.Parse(Console.ReadLine());
            switch(option)
            {
                case 1:
                {
                    string line;
                    StreamReader sr = null;
                    try
                    {
                        //Pass the file path and file name to the streamreader constructor
                        sr = new StreamReader("TestFolder/Test.txt");
                        line = sr.ReadLine();

                        while(line!=null)
                        {
                            //write the line to console window
                            Console.WriteLine(line);
                            //read the next line
                            line =sr.ReadLine();
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine($"Exception: {e.Message}");
                    }
                    finally
                    {
                        Console.WriteLine("Executing finally block.");
                        sr.Close();
                    }
                    break;
                }
                case 2:
                {
                    StreamWriter sw = null;
                    try
                    {
                    string [] old = File.ReadAllLines("TestFolder/Test.txt");
                    sw = new StreamWriter("TestFolder/Test.txt");
                    Console.WriteLine("Enter the new content to be included:");
                    string info = Console.ReadLine();

                    string old1 ="";
                    foreach(string text in old)
                    {
                        old1 = old1+"\n"+text;
                    }
                        old1 =old1+"\n"+info;
                        sw.WriteLine(old1);
                    
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine($"Exception: {e.Message}");
                    } 
                    finally
                    {
                        sw.Close();
                    }
                    break;
                }
            }

        }
    }

}
   
