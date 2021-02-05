
using System.Threading.Tasks;

using APX.Models;

namespace APX.Repositories
{
    public interface ICodeRepository : IRepository<Code>
    {
        Task<Code> FindById(string id);

        Task<bool> IsExistById(string id);
    }
}