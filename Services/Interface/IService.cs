
using System.Threading.Tasks;
using System.Collections.Generic;

using APX.Services.Parameter;

namespace APX.Services
{
    public interface IService<T>
    {
        Task<T> Create(IParameter parameter);

        Task<IEnumerable<T>> FindAll();
    }
}