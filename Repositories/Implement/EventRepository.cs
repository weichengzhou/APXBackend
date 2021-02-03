
using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using APX.Models;

namespace APX.Repositories
{
    public class EventRepository
        : AsyncRepository<Event>, IEventRepository
    {
        public EventRepository(DbContext context) : base(context)
        {
        }


        public async Task<Event> FindBySeq(string seq)
        {
            Expression<Func<Event, bool>> isExist = e => e.SEQ.ToString() == seq;
            return await this.FindFirst(isExist);
        }


        public async Task<bool> IsExistBySeq(string seq)
        {
            return await this.FindBySeq(seq) != null;
        }
    }
}