using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Services
{
    public interface ICategoryService
    {
        //public List<Category> GetAllCategories(int PageNumber = 1, int PageSize = 5);
        public List<Category> GetAllCategories();
        public void CreateCategory(Category category);
        public void DeleteCategory(Category category);
        public void UpdateCategory(Category category);
        public Category GetCategoryById(int id);
        public Category GetCategoryByName(string name);
        public int SaveCategory();
    }
}
