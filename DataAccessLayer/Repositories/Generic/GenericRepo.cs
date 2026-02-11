using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Generic
{
    public class GenericRepo<T> : IGenericRepo<T> 
        where T :class
    {

        private readonly ApplicationDbContext _dbContext;

        public GenericRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<T> GetById(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task Add(T entity)
        {
           await _dbContext.Set<T>().AddAsync(entity);
           await _dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllData()
        {
          return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task Remove(Guid id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            if (entity == null)
                return;
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
             _dbContext.Set<T>().Update(entity);
             await _dbContext.SaveChangesAsync();

        }
    }
}
