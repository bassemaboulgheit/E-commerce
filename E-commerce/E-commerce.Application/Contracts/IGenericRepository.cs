using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyEcommerce.Application.Contracts
{
    public interface IGenericRepository<T , TId>
    {
        public IQueryable<T> GetAll();
        public T GetById(TId pK);
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public int Save();
    }
}
