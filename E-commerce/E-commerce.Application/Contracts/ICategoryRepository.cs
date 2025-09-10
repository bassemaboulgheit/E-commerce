using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEcommerce.Models;

namespace MyEcommerce.Application.Contracts
{
    public interface ICategoryRepository
    {
        public IQueryable<Category> GetAll();
        public void Create(Category category);
        public void Update(Category category);
        public void Delete(Category category);
        public int Save();
    }
}
