
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using APX.Repositories;

namespace APX.Services.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(DbContext context,
            ICodeKindRepository codeKindRepository,
            ICodeRepository codeRepository,
            IEventRepository eventRepository,
            ITokenRepository tokenRepository)
        {
            this.Context = context;
            this.CodeKindRepository = codeKindRepository;
            this.CodeRepository = codeRepository;
            this.EventRepository = eventRepository;
            this.TokenRepository = tokenRepository;
        }
        
        public async Task SaveChanges()
        {
            await this.Context.SaveChangesAsync();
        }
        
        public ICodeKindRepository CodeKindRepository { get; private set; }
        public ICodeRepository CodeRepository { get; private set; }
        public IEventRepository EventRepository { get; private set; }
        public ITokenRepository TokenRepository { get; private set; }

        public DbContext Context { get; private set; }
    }
}