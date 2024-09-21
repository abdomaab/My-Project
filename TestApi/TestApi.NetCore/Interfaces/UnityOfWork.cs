using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.EF;
using TestApi.EF.Models;

namespace TestApi.NetCore.Interfaces
{
    public class UnityOfWork: IUnityOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IBaserepository<Book> Books;
        private readonly IBaserepository<User> Users;


        IBaserepository<Book> IUnityOfWork.Books => Books;

        IBaserepository<User> IUnityOfWork.Users => Users;

        public UnityOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            Books = new Baserepository<Book>(_context, _userManager);
            Users = new Baserepository<User>(_context, _userManager);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
