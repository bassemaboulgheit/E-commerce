using E_commerce.Application.Contracts;
using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace E_commerce.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<(bool Success, string Message, User Data)> LoginAsync(string username, string password)
        {

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return (false, "Username or Password cannot be empty", null);


            var user = await _userRepository.LoginAsync(username.Trim(), password.Trim());

            if (user == null)
                return (false, "Invalid username or password", null);

            if (user.Role == "Admin")
            {
                return (true, "Login successful as Admin", user);
            }
            else if (user.Role == "Customer")
            {
                return (true, "Login successful as Customer", user);
            }
            else
            {
                return (false, "Invalid username or password", null);
            }


        }

        public async Task<(bool Success, string Message)> RegisterAsync(string username, string email, string password, string confirmPassword)
        {
            // 1. Validation
            if (string.IsNullOrWhiteSpace(username))
                return (false, "Please enter a username");

            if (string.IsNullOrWhiteSpace(email))
                return (false, "Please enter an email");

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return (false, "Invalid email format");

            if (string.IsNullOrWhiteSpace(password))
                return (false, "Please enter a password");

            if (password != confirmPassword)
                return (false, "Passwords do not match");

            //2.Check if email already exists
            var exists = await _userRepository.ExistsByEmailAsync(email);
            if (exists)
                return (false, "Email already registered");



            var user = new User
            {
                Name = username.Trim(),
                Email = email.Trim(),
                Password = password.Trim(),
                Role = "Customer" 
            };

            await _userRepository.AddAsync(user);
            
            _userRepository.saveChanges();

            return (true, "Registration successful! You can now log in.");
        }

        public async Task AddAsync(User user)
        {
            User user1 = new User
            {
                Name = user.Name.Trim(),
                Email = user.Email.Trim(),
                Password = user.Password.Trim()
            };
            await _userRepository.AddAsync(user1);
        }
        public void saveChanges()
        {
            _userRepository.saveChanges();
        }

    }
}
