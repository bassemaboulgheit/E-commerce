using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Services
{
    public interface IUserService
    {
        public Task<(bool Success, string Message, User Data)> LoginAsync(string username, string password);
        public Task<(bool Success, string Message)> RegisterAsync(string username, string email, string password, string confirmPassword);

        public void saveChanges();
        Task AddAsync(User user);

    }
}
