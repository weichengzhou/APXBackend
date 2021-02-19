
using System.Threading.Tasks;

using APX.Models;

namespace APX.Repositories
{
    public interface ICodeRepository : IRepository<Code>
    {
        Task<Code> FindByID(string id);

        Task<bool> IsExistByID(string id);
    }
}