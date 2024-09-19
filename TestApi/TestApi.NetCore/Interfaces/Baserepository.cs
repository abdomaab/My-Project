using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.EF;

namespace TestApi.NetCore.Interfaces
{
    public class Baserepository<T> : IBaserepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        public Baserepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public T AddOne(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public T Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
            return entity;
        }

        

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Update(int id, T entity)
        {
            _context.Set<T>().Find(id);
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
