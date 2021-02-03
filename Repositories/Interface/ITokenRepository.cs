
using System.Threading.Tasks;

using APX.Models;

namespace APX.Repositories
{
    public interface ITokenRepository : IRepository<Token>
    {
        Task<Token> FindBySeq(string seq);

        Task<bool> IsExistBySeq(string seq);
    }
}