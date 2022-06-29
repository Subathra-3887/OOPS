using System;
using System.Collections.Generic;

namespace BinarySearch
{
    class Program
    {
            static int BinarySearch(List<Students> array, string element, out Students student)
            {
                int left =0,right = array.Count-1;
                while(left<=right)
                {
                    int middle = left +(right-left)/2;

                    if(array[middle].RegistrationId==element)
                    {
                        student = array[middle];
                        return middle;
                    }
                    if(array[middle].RegistrationId.CompareTo(element)<0)
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
            static void Main(string[] args)
            {
                List<Students> studentList = new List<Students>();
                studentList.Add(new Students(){RegistrationId= "SF1",StudentName="Suba"});
                studentList.Add(new Students(){RegistrationId= "SF2",StudentName="Usha"});
                studentList.Add(new Students(){RegistrationId= "SF3",StudentName="Nithiesh"});
                studentList.Add(new Students(){RegistrationId= "SF4",StudentName="Ravi"});
                studentList.Add(new Students(){RegistrationId= "SF5",StudentName="Baskaran"});
                studentList.Add(new Students(){RegistrationId= "SF6",StudentName="Preethi"});

                string element = "SF5";

                Students student;
                int result = BinarySearch(studentList,element,out student);
                if(result == -1)
                {
                    Console.WriteLine("Element not present");
                }
                else
                {
                    Console.WriteLine($"Element found at index {result} \nRegister ID: {student.RegistrationId} \nName: {student.StudentName}");
                }

            }
    }

}
   
