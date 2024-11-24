using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandHandler
{
    public interface IRepositoryQuery<T> where T : class
    {
        ValueTask<T> GetByidAsync(int id);
        ValueTask<IEnumerable<T>> GetAllAsync();
    }
}
