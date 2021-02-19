
using System.Threading.Tasks;
using System.Collections.Generic;

using APX.Models;
using APX.Models.Dto;

namespace APX.Services
{
    public interface ITokenService
    {
        Task<Token> Create(TokenDto tokenDto);

        Task<IEnumerable<Token>> FindAll();

        Task<Token> FindBySEQ(string seq);

        Task<bool> IsExistBySEQ(string seq);
    }
}