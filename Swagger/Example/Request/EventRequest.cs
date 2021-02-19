
using Swashbuckle.AspNetCore.Filters;

using APX.Models.Dto;

namespace APX.Swagger.Example
{
    public class CreateEventRequestExample : IExamplesProvider<EventDto>
    {
        public EventDto GetExamples()
        {
            return new EventDto
            {
                APISystem = "APS",
                APIName = "Get Token",
                APIVersion = "v1.0",
                Source = "Web API",
                Name = "APS.Get Token(2021/2/19 10:15:51)",
                Time = "2021/2/19 10:15:51",
                Flow = "IN",
                IPAddress = "127.0.0.1",
                Status = "Succeed",
                Desc = "Get JWT from APS",
                CreatedUser = "Frank"
            };
        }
    }


    public class UpdateEventRequestExample : IExamplesProvider<EventDto>
    {
        public EventDto GetExamples()
        {
            return new EventDto
            {
                APISystem = "APS",
                APIName = "Get Token",
                APIVersion = "v1.1",
                Source = "Web API Called",
                Name = "APS.GetToken(210219101551)",
                Time = "2021/2/19 21:47:15",
                Flow = "IN",
                IPAddress = "127.0.0.1",
                Status = "Succeed",
                Desc = "Get JWT from APS",
                UpdatedUser = "Bob"
            };
        }
    }
}