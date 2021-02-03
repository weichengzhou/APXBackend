
using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using APX.Models;

namespace APX.Repositories
{
    public class TokenRepository
        : AsyncRepository<Token>, ITokenRepository
    {
        public TokenRepository(DbContext context) : base(context)
        {
        }


        public async Task<Token> FindBySeq(string seq)
        {
            Expression<Func<Token, bool>> isExist = t => t.SEQ.ToString() == seq;
            return await this.FindFirst(isExist);
        }


        public async Task<bool> IsExistBySeq(string seq)
        {
            return await this.FindBySeq(seq) != null;
        }
    }
}