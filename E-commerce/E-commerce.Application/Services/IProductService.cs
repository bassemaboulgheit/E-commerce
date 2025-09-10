using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEcommerce.Models;

namespace MyEcommerce.Application.Services
{
    public interface IProductService
    {
        public List<Product> GetAllProducts();
        public void CreateProduct(Product NewProd);
        public void UpdateProduct(Product NewProd);
        public void DeleteProduct(Product NewProd);
        public int Save();
    }
}
