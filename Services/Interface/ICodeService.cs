
using System.Threading.Tasks;
using System.Collections.Generic;

using APX.Models;
using APX.Models.Dto;

namespace APX.Services
{
    public interface ICodeService
    {
        Task<Code> Create(CreateCodeDto codeDto);

        Task<IEnumerable<Code>> FindAll();

        Task<Code> FindById(string id);

        Task<Code> UpdateById(string id, CodeDto codeDto);

        Task<bool> IsExistById(string id);
    }
}