using E_commerce.Application.Contracts;
using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Services
{
    public class CategoryService : ICategoryService
    {
        //ICategoryRepository _CategoryRepo;
        IGenericRepository<Category, int> _CategoryRepo;

        public CategoryService(IGenericRepository<Category, int> catrepo)
        {
            _CategoryRepo = catrepo;
        }
        public List<Category> GetAllCategories()
        {
            //IQueryable<Category> allcategoriesquery = _CategoryRepo.GetAll();
            //var allcats = allcategoriesquery.Where(c => c.Products.Count > 0)
            //    .Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList()
                //.Adapt<List<Category>>();
            //return allcats;
            return _CategoryRepo.GetAll().ToList();
        }

        public void CreateCategory(Category category)
        {
            Category newcat = new Category()
            {
                Name = category.Name,
                Description = category.Description

            };
            //Category newcat = category.Adapt<Category>();
            _CategoryRepo.create(newcat);
        }

        public void DeleteCategory(Category category)
        {
            if (category != null)
            {
                category.IsDeleted = true;
            }
            else
            {
                throw new Exception("Category not found");
            }
            _CategoryRepo.delete(category);
        }

        public void UpdateCategory(Category category)
        {
            _CategoryRepo.Update(category);
        }

        public Category GetCategoryById(int id)
        {
            return _CategoryRepo.GetById(id);
        }

        public Category GetCategoryByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return null;

            return _CategoryRepo.GetAll().FirstOrDefault(c => c.Name.ToLower() == name.ToLower());
            //return _CategoryRepo.GetByName(name);
        }

        public int SaveCategory()
        {
            return _CategoryRepo.Save();
        }
    }
}
