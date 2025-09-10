using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using MyEcommerce.DTOs.CategoriesDTOs;
using MyEcommerce.Models;

namespace MyEcommerce.Application.Services
{
    public interface ICategoryService
    {
        public List<CategoryDTO> GetAllCategories();
        public void CreateCategory(CategoryDTO newCat);
        public void UpdateCategory(CategoryDTO categoryDto);
        public void DeleteCategory(CategoryDTO categoryDto);
        public int Save();
    }
}
