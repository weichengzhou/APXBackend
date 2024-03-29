
using System.Threading.Tasks;
using System.Collections.Generic;

using APX.Models;
using APX.Models.Dto;

namespace APX.Services
{
    public interface ICodeKindService
    {
        Task<CodeKind> Create(CodeKindDto kindDto);

        Task<IEnumerable<CodeKind>> FindAll();

        Task<CodeKind> FindByName(string name);

        Task<CodeKind> UpdateByName(string name, CodeKindDto kindDto);

        Task<bool> IsExistByName(string name);
    }
}