using E_commerce.Application.Contracts;
using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Services
{
    public class ProdectService : IProdectService
    {
        //ICategoryRepository _CategoryRepo;
        IGenericRepository<Product, int> _ProductRepo;

        public ProdectService(IGenericRepository<Product, int> prorepo)
        {
            _ProductRepo = prorepo;
        }
        public List<Product> GetAllProducts()
        {
            //IQueryable<Category> allcategoriesquery = _CategoryRepo.GetAll();
            //var allcats = allcategoriesquery.Where(c => c.Products.Count > 0)
            //    .Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList()
            //.Adapt<List<Category>>();
            //return allcats;
            return _ProductRepo.GetAll().ToList();
        }

        public void CreateProduct(Product category)
        {
            Product newcat = new Product()
            {
                Name = category.Name,
                Description = category.Description,
                Price = category.Price,
                Stock = category.Stock,
                ImagePath = category.ImagePath
            };
            //Category newcat = category.Adapt<Category>();
            _ProductRepo.create(newcat);
        }

        public void DeleteProduct(Product prodect)
        {
            if (prodect != null)
            {
                prodect.IsDeleted = true;
            }
            else
            {
                throw new Exception("Prodect not found");
            }
            _ProductRepo.delete(prodect);
        }

        public void UpdateProduct(Product prodect)
        {
            _ProductRepo.Update(prodect);
        }

        public Product GetProductById(int id)
        {
            if (id <= 0)
                return null;
            return _ProductRepo.GetById(id);
        }

        public Product GetProductByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return null;

            return _ProductRepo.GetAll().FirstOrDefault(c => c.Name.ToLower() == name.ToLower());
            //return _ProductRepo.GetByName(name);
        }

        public int SaveProduct()
        {
            return _ProductRepo.Save();
        }
    }
}
