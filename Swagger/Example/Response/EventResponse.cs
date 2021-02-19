
using System.Collections.Generic;

using APX.Models;

namespace APX.Swagger.Example
{
    public class CreateEventResponseExample : SucceedResponseExample<Event>
    {
        public override Event Result
        {
            get => EventExampleFactory.CreateGetTokenEvent();
        }


        public override string Message
        {
            get => "Event is created.";
        }
    }


    public class GetEventsResponseExample : SucceedResponseExample<List<Event>>
    {
        public override List<Event> Result
        {
            get
            {
                return new List<Event>
                {
                    EventExampleFactory.CreateGetTokenEvent(),
                    EventExampleFactory.CreateSendMailEvent()
                };
            }
        }


        public override string Message
        {
            get => "Find 2 records.";
        }
    }


    public class GetEventResponseExample : SucceedResponseExample<Event>
    {
        public override Event Result
        {
            get => EventExampleFactory.CreateGetTokenEvent();
        }


        public override string Message
        {
            get => "Find Event SEQ 1.";
        }
    }


    public class UpdateEventResponseExample : SucceedResponseExample<Event>
    {
        public override Event Result
        {
            get => EventExampleFactory.UpdateGetTokenEvent();
        }


        public override string Message
        {
            get => "Update Event SEQ 1.";
        }
    }
}