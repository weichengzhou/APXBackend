
using System.Threading.Tasks;

using APX.Models;
using APX.Services.Parameter;

namespace APX.Services
{
    public interface ICodeService : IService<Code>
    {
        Task<Code> FindById(string id);

        Task<Code> UpdateById(string id, IParameter parameter);

        Task<bool> IsExistById(string id);
    }
}