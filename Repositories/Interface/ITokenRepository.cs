
using System.Threading.Tasks;

using APX.Models;

namespace APX.Repositories
{
    public interface ITokenRepository : IRepository<Token>
    {
        Task<Token> FindBySEQ(string seq);

        Task<bool> IsExistBySEQ(string seq);
    }
}