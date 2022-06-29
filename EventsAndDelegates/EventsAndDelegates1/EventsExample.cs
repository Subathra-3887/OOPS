using System;
namespace EventsAndDelegates
{
    public delegate void EventManager();   //User defined delegate
    public class EventsExample
    {
        private string _eventName;
        public static event EventManager eventLink = null; //User define event
        static int i;
        public EventsExample(string eventName)
        {
            _eventName=eventName;
        }
        public static void EventStarter()
        {
                i=0;
                Console.WriteLine("User Registration");
                HandleEvent();    //Calling Events triggering method
        }
        public static void HandleEvent()   //Events triggering method
        {
            Console.WriteLine("Starting the following events");
            eventLink(); //Events Trigger -> Like a click button
        }
        public void ShowEvent() //Explanation about the button click option
        {
            ++i;
            Console.WriteLine($"Event: {i} is: {_eventName} started");
        }
    }

    
}