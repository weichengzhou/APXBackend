
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using APX.Models;

namespace APX.Repositories
{
    public class CodeKindRepository
        : AsyncRepository<CodeKind>, ICodeKindRepository
    {
        public CodeKindRepository(DbContext context) : base(context)
        {
        }


        public async Task<CodeKind> FindByName(string name)
        {
            Expression<Func<CodeKind, bool>> isExist = k => k.Name == name;
            return await FindFirst(isExist);
        }


        public async Task<bool> IsExistByName(string name)
        {
            return await this.FindByName(name) != null;
        }
    }
}