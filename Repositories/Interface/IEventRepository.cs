
using System.Threading.Tasks;

using APX.Models;

namespace APX.Repositories
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<Event> FindBySeq(string seq);

        Task<bool> IsExistBySeq(string seq);
    }
}