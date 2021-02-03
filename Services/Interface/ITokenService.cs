
using System.Threading.Tasks;

using APX.Models;

namespace APX.Services
{
    public interface ITokenService : IService<Token>
    {
        Task<Token> FindBySeq(string seq);

        Task<bool> IsExistBySeq(string seq);
    }
}