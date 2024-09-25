using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly OrderConext _conext;

        public Repository(OrderConext conext)
        {
            _conext = conext;
        }

        public async Task CreateAsync(T entity)
        {
           await _conext.Set<T>().AddAsync(entity);
            await _conext.SaveChangesAsync();  
        }

        public async Task DeleteAsync(T entity)
        {
            _conext.Set<T>().Remove(entity);
           await  _conext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll()
        {
          return await  _conext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
           
            return await _conext.Set<T>().SingleOrDefaultAsync(filter);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _conext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _conext.Set<T>().Update(entity);
            await _conext.SaveChangesAsync();
        }
    }
}
