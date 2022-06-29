using System;
using System.Collections.Generic;
namespace EventsAndDelegates
{
    class Program
    {   
        
        static void Main(string[] args)
        {
            EventsExample event1 = new EventsExample("Quiz");
            EventsExample event2 = new EventsExample("Debugging");
            EventsExample event3 = new EventsExample("Presentation");
            EventsExample event4 = new EventsExample("Games");

            //Event registration by management
            // Subscribe to events
            EventsExample.eventLink += new EventManager(event1.ShowEvent);
            EventsExample.eventLink += new EventManager(event2.ShowEvent);
            EventsExample.eventLink += new EventManager(event3.ShowEvent);
            EventsExample.eventLink += new EventManager(event4.ShowEvent);

            //Process initiation
            EventsExample.EventStarter();  //Indirectly using method
            //EventExample.eventList();    //Directly using event trigger / invoking
            //eventLink?.Invoke();

            //Event Cancellation/deregisteration
            //Unsubscribe from event
            EventsExample.eventLink -= new EventManager(event4.ShowEvent);
            EventsExample.EventStarter();
            
        }
        
    }

}
   
