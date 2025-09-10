using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEcommerce.Application.Contracts;
using MyEcommerce.DTOs.CategoriesDTOs;
using MyEcommerce.Models;

namespace MyEcommerce.Application.Services
{
    public class ProductService : IProductService
    {
        IGenericRepository<Product, int> _productRepo;
        public ProductService(IGenericRepository<Product, int> Repo)
        {
            _productRepo = Repo;
        }
        public List<Product> GetAllProducts()
        {
            IQueryable<Product> allCategories = _productRepo.GetAll();
            return allCategories.ToList();
        }
        public void CreateProduct(Product NewProd)
        {
            _productRepo.Create(NewProd);
        }
        public void UpdateProduct(Product NewProd)
        {
            _productRepo.Update(NewProd);
        }
        public void DeleteProduct(Product NewProd)
        {
            _productRepo.Delete(NewProd);
        }

        public int Save()
        {
            return _productRepo.Save();
        }
    }
}
