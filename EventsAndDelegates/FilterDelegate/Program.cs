using System;
using System.Collections.Generic;
namespace FilterDelegate
{
    public delegate bool Filter(Person p);
    class Program
    {
        static void Main(string[] args)
        {
          Person person1 = new Person() {Name="John",Age=41};
          Person person2 = new Person() {Name="Jane",Age=69};
          Person person3 = new Person() {Name="Jake",Age=12};
          
          //Create a lsit of person object and fill it
          List<Person>  people = new List<Person>(){person1,person2,person3};
          
          //Invoke display people using inappropriate delegate
          DisplayPeople("Children:",people,IsChild);
          DisplayPeople("Adults:",people,IsAdult);
          DisplayPeople ("Senior:",people,IsSenior);
          DisplayPeople("Voter:",people,IsVoter);

        }
        static void DisplayPeople(string title, List<Person>people ,Filter filter)
        {
            Console.WriteLine(title);

            foreach(Person p in people)
            {
                if (filter(p))
                {
                    Console.WriteLine($"{p.Name}, {p.Age} years old");
                }
            }
        }
        static bool IsChild(Person p)
        {
            return p.Age<15;
        }
        static bool IsVoter(Person p)
        {
            return p.Age>=18;
        }
        static bool IsAdult(Person p)
        {
            return p.Age>=18;
        }
        static bool IsSenior(Person p)
        {
            return p.Age>=65;
        }
    }

}
   
