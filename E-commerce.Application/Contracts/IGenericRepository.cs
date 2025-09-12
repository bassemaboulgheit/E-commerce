using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Contracts
{
    public interface IGenericRepository<T , TId> 
    {
        public IQueryable<T> GetAll();
        public T GetById(TId pk);
        //public T GetByName(T name);
        public void create(T entity);
        public void Update(T entity);
        public void delete(T entity);
        public int Save();
    }
}
