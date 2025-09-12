using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Contracts
{
    public interface IUserRepository
    {
        public Task<User> LoginAsync(string username, string password);
        public IQueryable<User> GetAll();

        public Task Register(User user);

        public void saveChanges();
        Task<bool> ExistsByEmailAsync(string email);
        Task AddAsync(User user);
    }
}
