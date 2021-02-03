
using System.Threading.Tasks;

using APX.Models;
using APX.Services.Parameter;

namespace APX.Services
{
    public interface IEventService : IService<Event>
    {
        Task<Event> FindBySeq(string seq);

        Task<Event> UpdateBySeq(string seq, IParameter parameter);

        Task<bool> IsExistBySeq(string seq);
    }
}