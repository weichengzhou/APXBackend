
using System.Threading.Tasks;
using System.Collections.Generic;

using APX.Models;
using APX.Models.Dto;

namespace APX.Services
{
    public interface IEventService
    {
        Task<Event> Create(CreateEventDto eventDto);

        Task<IEnumerable<Event>> FindAll();


        Task<Event> FindBySeq(string seq);

        Task<Event> UpdateBySeq(string seq, UpdateEventDto parameter);

        Task<bool> IsExistBySeq(string seq);
    }
}