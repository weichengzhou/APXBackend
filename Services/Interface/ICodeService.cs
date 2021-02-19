
using System.Threading.Tasks;
using System.Collections.Generic;

using APX.Models;
using APX.Models.Dto;

namespace APX.Services
{
    public interface ICodeService
    {
        Task<Code> Create(CodeDto codeDto);

        Task<IEnumerable<Code>> FindAll();

        Task<Code> FindByID(string id);

        Task<Code> UpdateByID(string id, CodeDto codeDto);

        Task<bool> IsExistByID(string id);
    }
}