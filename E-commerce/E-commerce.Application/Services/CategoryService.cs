using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using MyEcommerce.Application.Contracts;
using MyEcommerce.DTOs.CategoriesDTOs;
using MyEcommerce.Models;

namespace MyEcommerce.Application.Services
{
    //public class CategoryService : ICategoryService
    //{

    //    ICategoryRepository _categoryRepo;
    //    public CategoryService(ICategoryRepository Repo)
    //    {
    //        _categoryRepo = Repo;
    //    }
    //    public List<Category> GetAllCategories()
    //    {
    //        IQueryable<Category> allCategories = _categoryRepo.GetAll();
    //        return allCategories.Where(c => c.products.Count >= 0).ToList();
    //    }
    //    public void CreateCategory(Category NewCat)
    //    {;
    //        _categoryRepo.Create(NewCat);
    //    }
    //    public void UpdateCategory(Category category)
    //    {
    //        _categoryRepo.Update(category);
    //    }
    //    public void DeleteCategory(Category category)
    //    {
    //        _categoryRepo.Delete(category);
    //    }

    //    public int Save()
    //    {
    //        return _categoryRepo.Save();
    //    }
    //}
    public class CategoryService : ICategoryService
    {
        IGenericRepository<Category, int> _categoryRepo;
        public CategoryService(IGenericRepository<Category, int> Repo)
        {
            _categoryRepo = Repo;
        }
        public List<CategoryDTO> GetAllCategories()
        {
            IQueryable<Category> allCategories = _categoryRepo.GetAll();
            return allCategories.Where(c => c.products.Count >= 0).ToList().Adapt<List<CategoryDTO>>();
        }
        public void CreateCategory(CategoryDTO newCat)
        {
            var category = newCat.Adapt<Category>();
            _categoryRepo.Create(category);
        }
        public void UpdateCategory(CategoryDTO categoryDto)
        {
            var entity = _categoryRepo.GetById(categoryDto.CategoryID);
            if (entity != null)
            {
                categoryDto.Adapt(entity);
                //entity.Name = categoryDto.CategoryName;
                //entity.Description = categoryDto.Cat_Description;
                //_categoryRepo.Update(entity);
                _categoryRepo.Update(entity);
            }
        }
        public void DeleteCategory(CategoryDTO categoryDto)
        {
            var entity = _categoryRepo.GetById(categoryDto.CategoryID);
            if (entity != null)
            {
                _categoryRepo.Delete(entity);
            }
        }
        public int Save()
        {
            return _categoryRepo.Save();
        }
    }
}
