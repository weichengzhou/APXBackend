
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using APX.Models;

namespace APX.Repositories
{
    public class CodeRepository
        : AsyncRepository<Code>, ICodeRepository
    {
        public CodeRepository(DbContext context) : base(context)
        {
        }


        public async Task<Code> FindByID(string id)
        {
            Expression<Func<Code, bool>> isExist = c => c.ID == id;
            return await this.FindFirst(isExist);
        }


        public async Task<bool> IsExistByID(string id)
        {
            return await this.FindByID(id) != null;
        }
    }
}