using System;
using System.Collections.Generic;
using System.IO;
namespace CollegeAdmission
{
    /// <summary>
    /// Used to select a student's gender information
    /// </summary>
    public enum Gender{Default,Male,Female,Others}
    /// <summary>
    /// Class <see cref = "StudentDetails"/> used to collect student's details for the admission process
    /// </summary>
    public class StudentDetails
    {   
        /// <summary>
        /// Static field used to auto increment and it uniqely idetifies of <see cref = "StudentDetails"/> class
        /// </summary>
        private static int s_registrationNumber=3000;//Field
        /// <summary>
        /// Property RegisterNumber used to uniquely identify a <see cref = "StudentDetails"/> class' Object 
        /// </summary>
        public string RegistrationId {get;} //Property
        /// <summary>
        /// Property Name used to provide name for the student in object of <see cref="StudentDetails"/> class
        /// </summary>
        public string StudentName { get; set; } //Auto Property
        /// <summary>
        /// Property FatherName used to provide father's name for the student in object of <see cref ="StudentDetails"/> class
        /// </summary>
        public string FatherName { get; set; }
        /// <summary>
        /// Property DOB used to provide date of birth for the student in object of <see cref = "StudentDetails"/>class
        /// </summary>
        /// <value></value>
        public DateTime DOB { get; set; }
        /// <summary>
        /// Property Gender used to provide gender of student in object of<see cref = "StudentDetails"/> class
        /// </summary>
        /// <value></value>
        public Gender Gender { get; set; }
        /// <summary>
        /// Property MobileNumber used to provide mobile number of student in object of<see cref="StudentDetails"/> class
        /// </summary>
        /// <value></value>
        public long MobileNumber { get; set; }
        /// <summary>
        /// Property EmailId used to provide email Id of student in object of <see cref = "StudentDetails"/>class
        /// </summary>
        /// <value></value>
        public string EmailId { get; set; }
        /// <summary>
        /// Property Physics used to provide Physics marks of student in object of <see cref = "StudentDetails"/>class
        /// </summary>
        /// <value></value>
        public int Physics { get; set; }
        /// <summary>
        /// Property Chemistry used to provide chemistry marks of student in object of <see cref = "StudentDetails"/>class
        /// </summary>
        /// <value></value>
        public int Chemistry { get; set; }
        /// <summary>
        /// Property Maths used to provide maths marks of student in object of <see cref = "StudentDetails"/>class
        /// </summary>
        /// <value></value>
        public int Maths { get; set; }
         //Parameterized constructor
         /// <summary>
         /// Constructor of <see cref="StudentDetails"/> class used to initialize values to its properties
         /// </summary>
         /// <param name="name">Parameter name used to initialize a student's Name to Name property</param>
         /// <param name="fatherName">Parameter fatherName used to initialize a student's father name to FatherName property </param>
         /// <param name="dob">Parameter dob used to initialize a student's date of birth to DOB Property</param>
         /// <param name="gender">Parameter gender used to initialize a student's gender to Gender property</param>
         /// <param name="mobileNumber">Parameter mobileNumber used to initialize a student's mobile number to MobileNumber property</param>
         /// <param name="emailId">Parameter emailId used to initialize a student's email Id to EmailId property</param>
         /// <param name="physics">Paramter physics used to initialize a student's physics marks to Physics property</param>
         /// <param name="chemistry">Paramter chemistry used to initialize a student's chemistry marks to Chemistry property</param>
         /// <param name="maths">Parameter maths used to initailize a student's maths marks to Maths property</param>
        public StudentDetails(string name,string fatherName,DateTime dob, Gender gender,long mobileNumber,string emailId,int physics,int chemistry,int maths)
        {
            s_registrationNumber++;
            RegistrationId = "SF"+s_registrationNumber;
            StudentName = name;
            FatherName = fatherName;
            DOB = dob;
            Gender = gender;
            MobileNumber = mobileNumber;
            EmailId = emailId;
            Physics = physics;
            Chemistry = chemistry;
            Maths = maths;
        }
        /// <summary>
        /// Method Display used to display the details of the student
        /// </summary>
        // public void Display()  //Method
        // {
        //     Console.WriteLine("\nStudent Details:");
        //     Console.WriteLine($"Registration Number: {RegistrationId} \nName: {StudentName} \nFather's Name: {FatherName} \nDOB: {DOB} \nGender: {Gender} \nMobile Number: {MobileNumber} \nEmail Id: {EmailId} \nPhysics: {Physics} \nChemistry: {Chemistry} \nMaths: {Maths}");
            
        // }
        /// <summary>
        /// Method Calculate used to calculate and display the total and average of a student's marks
        /// </summary>
        public void Calculate()
        {
            int total = (Physics+Chemistry+Maths);
            double average = (double) total/3.0;
            Console.WriteLine($"Total Marks is:{total} \tAverage is: {average}");
        }
        /// <summary>
        /// Method CheckEligibility used to eligibility of a student based on cutOff 
        /// If cutOff is less or equal then he is eligible and return true else false
        /// </summary>
        /// <param name="cutOff">Used to provide cutOff value for eligibility checking</param>
        /// <returns>Return true if eligible else false</returns>
        public bool CheckEligibility(double cutOff)
        {
            double average = (double)(Maths+Chemistry+Physics)/3;
            if(average>=cutOff)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class Program
    {
        static List<StudentDetails> studentList = new List<StudentDetails>();
        static StudentDetails currentUSer = null;
      
       public static void Main(string[] args)
       {    
          
           int option;
           do
           {    
                Console.WriteLine();
                Console.WriteLine("Select Main Menu");
                Console.WriteLine("1.Registration \n2.Login \n3.Exit");
                option = int.Parse(Console.ReadLine());
                switch(option)
                {
                    case 1:
                    {
                        Registration();
                        break;
                    }
                    case 2:
                    {   
                        //Login();
                        break;
                    }
                    case 3:
                    {
                        break;
                    }
                }
                }while(option!=3);
            }
        /// <summary>
        /// Method Registration used to register the details of a student and add it to studentList
        /// </summary>
    public static void Registration()
    {   
            Console.WriteLine("Enter your Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your Father's Name:");
            string fatherName = Console.ReadLine();
            Console.WriteLine("Enter your DOB :");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            Console.WriteLine("Select your gender 1.Male 2.Female 3.Others");
            int genderValue = int.Parse(Console.ReadLine());
            Gender gender=Gender.Default;
            while(!(genderValue>0 && genderValue<4))
            {
                Console.WriteLine("Select your gender 1.Male 2.Female 3.Others");
                genderValue = int.Parse(Console.ReadLine());
            }
             gender=(Gender)genderValue;
            Console.WriteLine("Enter your mobile number:");
            long mobileNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter your email Id:");
            string emailId = Console.ReadLine();
            Console.WriteLine("Enter your marks(Physics):");
            int physics = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your marks(Chemistry):");
            int chemistry = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your marks(Mathematics):");
            int maths = int.Parse(Console.ReadLine());

            StudentDetails student = new StudentDetails(name,fatherName,dob,gender,mobileNumber,emailId,physics,chemistry,maths);
            Console.WriteLine($"Registration Id:{student.RegistrationId}");
            //Add printout to file
            studentList.Add(student);
            Insert(studentList);
            Display();
    }
    public static void Insert(List<StudentDetails>studentList)
    {
        StreamWriter write = null;
            if(!File.Exists("Data.csv"))
            {
                File.Create("Data.csv");
            }
            else
            {
                write = new StreamWriter(File.OpenWrite("Data.csv"));
                foreach(var v in studentList)
                {
                    write.WriteLine(v.StudentName+","+v.FatherName+","+v.DOB+","+v.Gender+","+v.MobileNumber+","+v.EmailId+","+v.Physics+","+v.Chemistry+","+v.Maths);
                }
                write.WriteLine();
            }
            write.Close();
        }
    }
    static void Display()
        {
            StreamReader reader = null;
            List<StudentDetails> listA = new List<StudentDetails>();
            if(!File.Exists("Data.csv"))
            {
                reader = new StreamReader(File.OpenRead("Data.csv"));
                while(!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if(values[0]!="" && values[0]!="n")
                    {
                        listA.Add(new StudentDetails(values[1],values[2],DateTime.Parse(values[3]),(Gender)Enum.Parse(typeof(Gender),values[4]),long.Parse(values[5]),values[6],int.Parse(values[7]),int.Parse(values[8]),int.Parse(values[9])));
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
                Console.WriteLine($"Your Name: {column1.StudentName} \nFather Name: {column1.FatherName} \nDOB: {column1.DOB} \nGender: {column1.Gender} \nMobile Number: {column1.MobileNumber} \nEmailID: {column1.EmailId} \nPhysics: {column1.Physics} \nChemistry: {column1.Chemistry} \nMaths: {column1.Maths}");
            }  
        }
     
    // public static void Login()
    // {
    //     Console.WriteLine("Enter your Registration ID:");
    //     string registrationID = Console.ReadLine().ToUpper();

    //     foreach(StudentDetails student in studentList)
    //     {
        
    //     if(registrationID==student.RegistrationId)
    //     {
            
    //             Console.WriteLine("Login Successfull");
    //             currentUSer = student;
    //             SubMenu();
    //     }
    //     }
    // }
    // static void SubMenu ()
    // {
    //     int option;
    //     do
    //     {   
    //         Console.WriteLine();
    //         Console.WriteLine("Select Sub Menu:\n1.Display Details \n2.Calculate total and average \n3.Check eligibility \n4.Exit");
    //         option = int.Parse(Console.ReadLine());
    //         switch(option)
    //         {
    //             case 1:
    //             {   
    //                 currentUSer.Display();
    //                 break;
    //             }
    //             case 2:
    //             {
    //                 currentUSer.Calculate();
    //                 break;
    //             }
    //             case 3:
    //             {
    //                 bool eligible = currentUSer.CheckEligibility(75.0);
    //                 if(eligible)
    //                 {
    //                     Console.WriteLine("You are eligible for admission");
    //                 }
    //                 else
    //                 {
    //                     Console.WriteLine("You are not eligible for admission");
    //                 }
    //                 break;
    //             }
                
    //         }
    //     }while(option!=4);
    //     Console.WriteLine();   
    // }
    }



   
