
using System.Threading.Tasks;

using APX.Models;
using APX.Services.Parameter;

namespace APX.Services
{
    public interface ICodeKindService : IService<CodeKind>
    {
        Task<CodeKind> FindByName(string name);

        Task<CodeKind> UpdateByName(string name, IParameter parameter);

        Task<bool> IsExistByName(string name);
    }
}