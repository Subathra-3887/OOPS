using System;
using System.IO;
using System.Collections.Generic;

namespace CollegeStudentUpdated
{
    public delegate bool Filter(double cutOff, double average);
    public partial class Operations
    {
        public static List<StudentDetails> studentList = new List<StudentDetails>();
       public static List<DepartmentDetails> departmentList = new List<DepartmentDetails>();
        public static List<AdmissionDetails> admissionList=new List<AdmissionDetails>();
        static StudentDetails currentUser = null;
        public static void ShowMainMenu()
        {
            string ans="yes";
            int option;
            do
            {
                Console.WriteLine("Main Menu: \n1.User Registration \n2.User Login \n3.Check Department Wise Seat Availability \n4.Exit");
                option = int.Parse(Console.ReadLine());
                switch(option)
                {
                    case 1:
                        {
                            StudentRegistration();
                            break;
                        }
                    case 2:
                        {
                            StudentLogin();
                            break;
                        }
                    case 3:
                        {
                            ShowDepartmentDetails();
                            break;
                        }
                    case 4:
                        {
                            ans ="no";
                            break;
                        }
                    }
            }while(ans=="yes");
               
        }
        public static void StudentRegistration()
        {
            Console.WriteLine("Enter your Name:");
            string studentName = Console.ReadLine();
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
            Console.WriteLine("Enter your marks(Physics):");
            int physics = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your marks(Chemistry):");
            int chemistry = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your marks(Mathematics):");
            int maths = int.Parse(Console.ReadLine());

            StudentDetails student = new StudentDetails(studentName,fatherName,dob,gender,physics,chemistry,maths);
            studentList.AddElement(student);
            Console.WriteLine($"Student ID: {student.StudentId}");
        }
        
        public static void StudentLogin()
        {
            Console.WriteLine("Enter your Registration ID:");
            string studentId = Console.ReadLine().ToUpper();
            string element = studentId;
            int result = BinarySearch(studentList,element,out currentUser);
                if(result == -1)
                {
                    Console.WriteLine("Element not present");
                }
                else
                {
                   ShowSubMenu();
                }
        }
         static int BinarySearch(List<StudentDetails> array, string element, out StudentDetails student)
            {
                int left =0,right = array.Count-1;
                while(left<=right)
                {
                    int middle = left +(right-left)/2;

                    if(array[middle].StudentId==element)
                    {
                        student = array[middle];
                        return middle;
                    }
                    if(array[middle].StudentId.CompareTo(element)<0)
                    {
                        left = middle+1;
                    }
                    else
                    {
                        right= middle-1;
                    }
                }
                student = null;
                return -1;
            }
        public static void ShowSubMenu()
            {
            string ch="";
            do
            {
                System.Console.WriteLine("\nSub Menu \n1.Check Eligiblity \n2.Show Details \n3.Take Admission \n4.Cancel Admission \n5.ShowAdmissionDetails \n6.Exit");
                int choice=int.Parse(Console.ReadLine());  
                switch (choice)
                {
                    case 1:
                    {
                        if(currentUser.CheckEligiblity(75.0,StudentDetails.filter))
                        {
                            Console.WriteLine("You are eligible ");
                        }
                        else
                        {
                            Console.WriteLine("You are not eligible");
                        }
                        break;
                    }
                    case 2:
                    {
                        ShowDetails();
                        break;
                    }
                    case 3:
                    {
                        TakeAdmission();
                        break;
                    }
                    case 4:
                    {
                        CancelAdmission();
                        break;
                    }
                    case 5:
                    {
                        ShowAdmissionDetails();
                        break;
                    }
                    case 6:
                    {
                        ch="no";
                        break;
                    }
                }
            }while(ch!="no");
        } 
        public static void ShowDepartmentDetails()
        {
            foreach(DepartmentDetails department in departmentList)
            {
                Console.WriteLine($"Department ID: {department.DepartmentId} \nDEpartment Name: {department.DepartmentName} \nNumber of Seats: {department.Seats}");
                Console.WriteLine();
            }
        }
        public static void ShowDetails()
        {
            foreach(StudentDetails student in studentList)
            {
                if(student.StudentId == currentUser.StudentId)
                {
                    Console.WriteLine($"Student ID: {student.StudentId} \nStudent Name: {student.StudentName}\nFather Name: {student.FatherName}\nDate Of Birth Is : {student.DOB}\nGender Is : {student.Gender}\nPhysics Mark Is : {student.Physics}\nChemistry Mark Is : {student.Chemistry}\nMaths Mark Is : {student.Maths}");
                    Console.WriteLine();
                }
            }
        }
        static AdmissionDetails admit= null;
            public static void TakeAdmission()
            {
                int count=1;
                foreach(DepartmentDetails department in departmentList)
                {
                    Console.WriteLine($"Department ID: {department.DepartmentId} \nDepartment Name: {department.DepartmentName} \nNumber of seats: {department.Seats}");
                }
                Console.WriteLine("Enter the Department ID you want to select:");
                string departmentId = Console.ReadLine();
                foreach(DepartmentDetails department in departmentList)
                {
                    
                    if(departmentId==department.DepartmentId)
                    {
                        if(currentUser.CheckEligiblity(75.0,StudentDetails.filter))
                        {
                            foreach(AdmissionDetails admission in admissionList)
                            {count++;
                                if(currentUser.StudentId==admission.StudentId && admission.Status==Status.Cancelled)
                                {
                                    if(department.Seats>1) 
                                    { 
                                    department.Seats=department.Seats-1;
                                    admit = new AdmissionDetails(currentUser.StudentId,departmentId,DateTime.Now,Status.Admitted);
                                    admissionList.AddElement(admit);
                                    Console.WriteLine($"Admission took successfully! Your Admission ID: {admit.AdmissionId}");
                                    }
                                }
                                
                            }

                            if(count>admissionList.Count )
                             {
                                    
                                        department.Seats=department.Seats-1;
                                      admit = new AdmissionDetails(currentUser.StudentId,departmentId,DateTime.Now,Status.Admitted);
                                      
                                      admissionList.AddElement(admit);
                                        Console.WriteLine($"Admission took successfully! Your Admission ID: {admit.AdmissionId}");
                            }
                        }
                    }    
                }

                 if(count>admissionList.Count && admit !=null)
                {  admissionList.AddElement(admit);
                                        Console.WriteLine($"Admission took successfully! Your Admission ID: {admit.AdmissionId}");
                }
                                 
            }

            public static void CancelAdmission()
            {
                foreach(AdmissionDetails admission in admissionList)
                {
                    if(admission.StudentId==currentUser.StudentId && admission.Status == Status.Admitted)
                    {
                        Console.WriteLine($"Admission ID: {admission.AdmissionId} \nStudent ID: {admission.StudentId} \nDepartment ID: {admission.DepartmentId} \nAdmission Date: {admission.AdmissionDate} \nAdmission Status: {admission.Status}");
                        foreach(DepartmentDetails department in departmentList)
                        {
                            if (admission.DepartmentId == department.DepartmentId)
                            {
                                department.Seats =department.Seats+1;
                                admission.Status = Status.Cancelled;
                                Console.WriteLine("Admission seat cancelled successfully");

                            }
                        }
                    }
                }
            }
            public static void ShowAdmissionDetails()
        {
            foreach(AdmissionDetails value in admissionList)
            {
                if(value.StudentId == currentUser.StudentId )
                {
                    Console.WriteLine($" Admission ID :{value.AdmissionId} \n Student ID : {value.StudentId} \n Department Id : {value.DepartmentId} \n Admission Date {value.AdmissionDate} \n Admission Status {value.Status}");
                    Console.WriteLine();
                }
            }
        }

        public static void DefaultAdmissionDetails()
        {
            StreamReader reader=null;
            if(File.Exists("AdmissionDetails.csv"))
            {
                reader=new StreamReader(File.OpenRead("AdmissionDetails.csv"));
                while(!reader.EndOfStream)
                {
                    var line =reader.ReadLine();
                    var values=line.Split(',');
                 
                    if(values[0]!="" && values[0]!="n")
                    {
                       
                       admissionList.AddElement(new AdmissionDetails(values[1],values[2], DateTime.ParseExact(values[3],"dd/MM/yyyy",null),(Status)Enum.Parse(typeof(Status),values[4])));
                    }
                }
            }
            else
            {
               File.Create("AdmissionDetails.csv");
            }         
            reader.Close();
        }
        public static void DepartmentDetails()
        {
            StreamReader reader = null;
            if(File.Exists("DepartmentDetails.csv"))
            {
                reader = new StreamReader(File.OpenRead("DepartmentDetails.csv"));
                while(!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if(values[0]!="" && values[0]!="n")
                    {
                        departmentList.AddElement(new DepartmentDetails (values[1], int.Parse(values[2])));
                    }
                }
            }
            else
            {
                File.Create("DepartmentDetails.csv");
            }
            reader.Close();
            
            
        }
        public static void ShowStudentDetails()
        {
            StreamReader reader = null;
            if(File.Exists("StudentDetails.csv"))
            {
                reader = new StreamReader(File.OpenRead("StudentDetails.csv"));
                while(!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if(values[0]!="" && values[0]!="n")
                    {
                        studentList.AddElement(new StudentDetails(values[1], values[2], DateTime.Parse(values[3]), (Gender)Enum.Parse(typeof(Gender), values[4]), int.Parse(values[5]), int.Parse(values[6]), int.Parse(values[7]) ));
                    }
                }
            }
            else
            {
                Console.WriteLine("File Does Not Exist");
                File.Create("StudentDetails.csv");
            }
            reader.Close();
             
        }
        public static void Insert(List<StudentDetails> studentList)
        {
            StreamWriter write = null;
            if(!File.Exists("StudentDetails.csv"))
            {
                File.Create("StudentDetails.csv");
            }
            else
            {
                write = new StreamWriter(File.OpenWrite("StudentDetails.csv"));
                foreach(StudentDetails student in studentList)
                {if(student!=null)
                    write.WriteLine(student.StudentId+","+student.StudentName+","+student.FatherName+","+student.DOB.ToString("dd/MM/yyyy")+","+student.Gender+","+student.Physics+","+student.Chemistry+","+student.Maths);
                }
            }
            write.Close();
        }
         public static void Insert(List<DepartmentDetails> departmentList)
        {
            StreamWriter write = null;
            if(!File.Exists("DepartmentDetails.csv"))
            {
                File.Create("DepartmentDetails.csv");
            }
            else
            {
                write = new StreamWriter(File.OpenWrite("DepartmentDetails.csv"));
                foreach(DepartmentDetails department in departmentList)
                {
                    write.WriteLine(department.DepartmentId+","+department.DepartmentName+","+department.Seats);
                }
            }
            write.Close();
        }
        public static void Insert(List<AdmissionDetails> admissionList)
        {
            StreamWriter write = null;
            if(!File.Exists("AdmissionDetails.csv"))
            {
                File.Create("AdmissionDetails.csv");
            }
            else
            {
                write = new StreamWriter(File.OpenWrite("AdmissionDetails.csv"));
                foreach(AdmissionDetails admission in admissionList)
                {
                    write.WriteLine(admission.AdmissionId+","+admission.StudentId +","+admission.DepartmentId+","+admission.AdmissionDate.ToString("dd/MM/yyyy")+","+admission.Status);
                }
            }
            write.Close();
        }
       
    }
}