
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using APX.Repositories;

namespace APX.Services.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICodeKindRepository CodeKindRepository { get; }
        ICodeRepository CodeRepository { get; }
        IEventRepository EventRepository { get; }
        ITokenRepository TokenRepository { get; }

        DbContext Context { get; }

        Task SaveChanges();
    }
}