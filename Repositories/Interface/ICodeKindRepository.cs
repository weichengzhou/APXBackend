
using System.Threading.Tasks;

using APX.Models;

namespace APX.Repositories
{
    public interface ICodeKindRepository : IRepository<CodeKind>
    {
        Task<CodeKind> FindByName(string name);

        Task<bool> IsExistByName(string name);
    }
}