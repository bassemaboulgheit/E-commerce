using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEcommerce.Models;

namespace MyEcommerce.Application.Contracts
{
    public interface IProductRepository
    {
        public IQueryable<Product> GetAll();
        public void Create(Product entity);
        public void Update(Product entity);
        public void Delete(Product entity);
        public int Save();
    }
}
