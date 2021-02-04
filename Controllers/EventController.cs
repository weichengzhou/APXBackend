
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using APXBackend.Controllers.Response;

using APX.Models.Dto;
using APX.Services;
using APX.Services.Exceptions;
using APX.Models;

namespace APXBackend.Controllers
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

        [HttpPost("api/v1.0/event/")]
        [Produces("application/json")]
        public async Task<IActionResult> CreateEvent([FromBody]CreateEventDto eventDto)
        {
            try
            {
                Event createdEvent = await this._service.Create(eventDto);
                string message = "Event is created.";
                return StatusCode(200, new SucceedResponse(message, createdEvent));
            }
            catch(ServiceError error)
            {
                return StatusCode(400, new ErrorResponse(error.Message));
            }
        }


        [HttpGet("api/v1.0/events/")]
        [Produces("application/json")]
        public async Task<IActionResult> FindAllEvents()
        {
            IEnumerable<Event> allEvents = await this._service.FindAll();
            string message = String.Format("Find {0} records.", allEvents.Count());
            return StatusCode(200, new SucceedResponse(message, allEvents));
        }


        [HttpGet("api/v1.0/event/{seq}")]
        [Produces("application/json")]
        public async Task<IActionResult> FindEvent([FromRoute]string seq)
        {
            try
            {
                Event findEvent = await this._service.FindBySeq(seq);
                string message = String.Format("Find event seq {0}.", seq);
                return StatusCode(200, new SucceedResponse(message, findEvent));
            }
            catch(ServiceError error)
            {
                return StatusCode(400, new ErrorResponse(error.Message));
            }
        }


        [HttpPut("api/v1.0/event/{seq}")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateEvent([FromRoute]string seq,
            [FromBody]UpdateEventDto eventDto)
        {
            try
            {
                Event updatedEvent = await this._service.UpdateBySeq(seq, eventDto);
                string message = String.Format("Update event seq {0}.", seq);
                return StatusCode(200, new SucceedResponse(message, updatedEvent));
            }
            catch(ServiceError error)
            {
                return StatusCode(400, new ErrorResponse(error.Message));
            }
        }

        #endregion
    }
}