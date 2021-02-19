
using System.Threading.Tasks;
using System.Collections.Generic;

using APX.Models;
using APX.Models.Dto;

namespace APX.Services
{
    public interface IEventService
    {
        Task<Event> Create(EventDto eventDto);

        Task<IEnumerable<Event>> FindAll();

        Task<Event> FindBySEQ(string seq);

        Task<Event> UpdateBySEQ(string seq, EventDto parameter);

        Task<bool> IsExistBySEQ(string seq);
    }
}