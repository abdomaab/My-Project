using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.EF.Models;

namespace TestApi.NetCore.Interfaces
{
    public interface IUnityOfWork: IDisposable
    {
        IBaserepository<Book> Books { get; }
        IBaserepository<User> Users { get; }
        int Complete();
    }
}
