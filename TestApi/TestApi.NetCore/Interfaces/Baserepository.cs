using Microsoft.AspNetCore.Identity;
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
        protected UserManager<ApplicationUser> _userManager;
        public Baserepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public T AddOne(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public T Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return entity;
        }

        public async Task<List<ApplicationUser>> GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Update(int id, T entity)
        {
            _context.Set<T>().Find(id);
            _context.Set<T>().Update(entity);
            return entity;
        }
    }
}
