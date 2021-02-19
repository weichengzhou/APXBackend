
using System;

using APX.Models;

namespace APX.Swagger.Example
{
    public class EventExampleFactory
    {
        static public Event CreateGetTokenEvent()
        {
            return new Event
            {
                SEQ = 1,
                APISystem = "APS",
                APIName = "Get Token",
                APIVersion = "v1.0",
                Source = "Web API",
                Name = "APS.Get Token(2021/2/19 10:15:51)",
                Time = new DateTime(2021, 2, 19, 10, 15, 51),
                Flow = "IN",
                IPAddress = "127.0.0.1",
                Status = "Succeed",
                Desc = "Get JWT from APS",
                CreatedUser = "Frank",
                CreatedDate = new DateTime(2021, 2, 19, 10, 17, 1),
                UpdatedUser = "Frank",
                UpdatedDate = new DateTime(2021, 2, 19, 10, 17, 1)
            };
        }


        static public Event UpdateGetTokenEvent()
        {
            return new Event
            {
                SEQ = 1,
                APISystem = "APS",
                APIName = "Get Token",
                APIVersion = "v1.1",
                Source = "Web API Called",
                Name = "APS.GetToken(210219101551)",
                Time = new DateTime(2021, 2, 19, 21, 47, 15),
                Flow = "IN",
                IPAddress = "127.0.0.1",
                Status = "Succeed",
                Desc = "Get JWT from APS",
                CreatedUser = "Frank",
                CreatedDate = new DateTime(2021, 2, 19, 10, 17, 1),
                UpdatedUser = "Bob",
                UpdatedDate = new DateTime(2021, 2, 21, 17, 24, 41)
            };
        }


        static public Event CreateSendMailEvent()
        {
            return new Event
            {
                SEQ = 2,
                APISystem = "APS",
                APIName = "Send Mail",
                APIVersion = "v1.2",
                Source = "Web API",
                Name = "APS.Send Mail(2021/2/21 20:1:31)",
                Time = new DateTime(2021, 2, 21, 20, 1, 31),
                Flow = "OUT",
                IPAddress = "192.168.0.0",
                Status = "Failed",
                Desc = "Send mail to agent",
                CreatedUser = "Frank",
                CreatedDate = new DateTime(2021, 2, 21, 20, 1, 31),
                UpdatedUser = "Bob",
                UpdatedDate = new DateTime(2021, 2, 23, 15, 25, 48)
            };
        }
    }
}