using E_commerce.Application.Contracts;
using E_commerce.Context;
using E_commerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.infrastructure
{

    public class UserRepository : IUserRepository
    {
        MyContext _context;
        public UserRepository(MyContext context)
        {
            _context = context;
        }

        public IQueryable<User> GetAll()
        {
            return _context.Users.AsQueryable();
        }
        public async Task<User> LoginAsync(string username, string password)
        {
            var users = GetAll();
            return await users.AsNoTracking().SingleOrDefaultAsync(u => (u.Email == username || u.Name == username) && u.Password == password);
        }

        public async Task Register(User user)
        {
            await _context.Users.AddAsync(user);
                
        }

        public void saveChanges()
        {
            _context.SaveChanges();
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

    }
}
