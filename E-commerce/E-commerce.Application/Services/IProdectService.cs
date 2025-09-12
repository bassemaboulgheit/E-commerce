using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Services
{
    public interface IProdectService
    {
        public List<Product> GetAllProducts();
        public void CreateProduct(Product category);
        public void DeleteProduct(Product category);
        public void UpdateProduct(Product category);
        public Product GetProductById(int id);
        public Product GetProductByName(string name);
        public int SaveProduct();
    }
}
