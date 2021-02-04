
using System.Threading.Tasks;
using System.Collections.Generic;

using APX.Models;
using APX.Models.Dto;

namespace APX.Services
{
    public interface ITokenService
    {
        Task<Token> Create(CreateTokenDto tokenDto);

        Task<IEnumerable<Token>> FindAll();

        Task<Token> FindBySeq(string seq);

        Task<bool> IsExistBySeq(string seq);
    }
}