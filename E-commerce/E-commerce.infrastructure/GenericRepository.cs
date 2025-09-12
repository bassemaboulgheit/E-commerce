using E_commerce.Application.Contracts;
using E_commerce.Context;
using E_commerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.infrastructure
{
    public class GenericRepository<T, TId> : IGenericRepository<T, TId> where T : BaseModels<TId>
    {
        MyContext MyEcommerceContext;
        DbSet<T> _dbset;

        public GenericRepository(MyContext Context)
        {
            MyEcommerceContext = Context;
            _dbset = MyEcommerceContext.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _dbset;
        }

        public T GetById(TId pk)
        {
            return _dbset.Find(pk);
        }
        //public T GetByName(T name)
        //{
        //    return _dbset.FirstOrDefault();
        //}

        public void create(T entity)
        {
            //MyEcommerceContext.Categories.Add(category);
            _dbset.Add(entity);
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
        }

        public void delete(T entity)
        {
            //MyEcommerceContext.Categories.Remove(category);
            _dbset.Remove(entity);
        }

        public int Save()
        {
            return MyEcommerceContext.SaveChanges();
        }
    }
}
