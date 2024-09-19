using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.NetCore.Interfaces
{
    public interface IBaserepository<T> where T : class
    {
        T GetById(int id);
        //IEnumerable<T> GetAll();
        T AddOne(T entity);
        T Update(int id, T entity);
        T Delete(T entity);
       
    }
}
