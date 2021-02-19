
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

using APX.Controllers.Response;

using APX.Models.Dto;
using APX.Services;
using APX.Services.Exceptions;
using APX.Models;
using APX.Swagger.Example;

namespace APX.Controllers
{
    [ApiController]
    public class EventController : ControllerBase
    {
        /* 使用 DI 方式導入 Service
        */
        private IEventService _service;

        public EventController(IEventService service)
        {
            _service = service;
        }

        #region api v1.0

        /// <response code="201">Created Event returns.</response>
        /// <response code="400">Inputs is not validated.</response>
        [HttpPost("api/v1.0/event/")]
        [Produces("application/json")]
        [SwaggerRequestExample(typeof(EventDto), typeof(CreateEventRequestExample))]
        [SwaggerResponse(201, Type=typeof(SucceedResponse<Event>))]
        [SwaggerResponseExample(201, typeof(CreateEventResponseExample))]
        [SwaggerResponse(400, Type=typeof(ErrorResponse))]
        [SwaggerResponseExample(400, typeof(ErrorResponseExample))]
        public async Task<IActionResult> CreateEvent([FromBody]EventDto eventDto)
        {
            try
            {
                Event createdEvent = await this._service.Create(eventDto);
                string message = "Event is created.";
                return StatusCode(200, new SucceedResponse<Event>(createdEvent, message));
            }
            catch(ServiceError error)
            {
                return StatusCode(400, new ErrorResponse(error.Message));
            }
        }


        /// <response code="200">Get list of Events.</response>
        [HttpGet("api/v1.0/events/")]
        [Produces("application/json")]
        [SwaggerResponse(200, Type=typeof(SucceedResponse<IEnumerable<Event>>))]
        [SwaggerResponseExample(200, typeof(GetEventsResponseExample))]
        public async Task<IActionResult> FindAllEvents()
        {
            IEnumerable<Event> allEvents = await this._service.FindAll();
            string message = String.Format("Find {0} records.", allEvents.Count());
            return StatusCode(200, new SucceedResponse<IEnumerable<Event>>(
                allEvents, message));
        }


        /// <response code="200">Get a specific Event by SEQ.</response>
        /// <response code="400">Event is not exist.</response>
        [HttpGet("api/v1.0/event/{seq}")]
        [Produces("application/json")]
        [SwaggerResponse(200, Type=typeof(SucceedResponse<Event>))]
        [SwaggerResponseExample(200, typeof(GetEventResponseExample))]
        [SwaggerResponse(400, Type=typeof(ErrorResponse))]
        [SwaggerResponseExample(400, typeof(ErrorResponseExample))]
        public async Task<IActionResult> FindEvent([FromRoute]string seq)
        {
            try
            {
                Event findEvent = await this._service.FindBySeq(seq);
                string message = String.Format("Find Event SEQ {0}.", seq);
                return StatusCode(200, new SucceedResponse<Event>(findEvent, message));
            }
            catch(ServiceError error)
            {
                return StatusCode(400, new ErrorResponse(error.Message));
            }
        }


        /// <response code="200">Update a specific Event by SEQ.</response>
        /// <response code="400">
        /// Event cannot update because
        /// - Inputs is not validated.
        /// - SEQ of Event is not exist.
        /// </response>
        [HttpPut("api/v1.0/event/{seq}")]
        [Produces("application/json")]
        [SwaggerRequestExample(typeof(EventDto), typeof(UpdateEventRequestExample))]
        [SwaggerResponse(200, Type=typeof(SucceedResponse<Event>))]
        [SwaggerResponseExample(200, typeof(UpdateEventResponseExample))]
        [SwaggerResponse(400, Type=typeof(ErrorResponse))]
        [SwaggerResponseExample(400, typeof(ErrorResponseExample))]
        public async Task<IActionResult> UpdateEvent([FromRoute]string seq,
            [FromBody]EventDto eventDto)
        {
            try
            {
                Event updatedEvent = await this._service.UpdateBySeq(seq, eventDto);
                string message = String.Format("Update Event SEQ {0}.", seq);
                return StatusCode(200, new SucceedResponse<Event>(updatedEvent, message));
            }
            catch(ServiceError error)
            {
                return StatusCode(400, new ErrorResponse(error.Message));
            }
        }

        #endregion
    }
}