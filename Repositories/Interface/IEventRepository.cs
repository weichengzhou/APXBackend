
using System.Threading.Tasks;

using APX.Models;

namespace APX.Repositories
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<Event> FindBySEQ(string seq);

        Task<bool> IsExistBySEQ(string seq);
    }
}