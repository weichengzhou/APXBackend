
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


        public async Task<Token> FindBySEQ(string seq)
        {
            Expression<Func<Token, bool>> isExist = t => t.SEQ.ToString() == seq;
            return await this.FindFirst(isExist);
        }


        public async Task<bool> IsExistBySEQ(string seq)
        {
            return await this.FindBySEQ(seq) != null;
        }
    }
}