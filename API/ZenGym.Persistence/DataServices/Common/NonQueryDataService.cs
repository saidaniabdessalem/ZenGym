using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZenGym.Domain.Common;
using ZenGym.Persistence;

namespace ZenGym.Persistence.DataServices.Common
{
    public class NonQueryDataService<T> where T : BaseEntity
    {
        private ZenGymDbContext _dbContext;

        public NonQueryDataService(ZenGymDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> CreateAsync(T entity)
        {
            EntityEntry<T> createdResult = await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return createdResult.Entity;
        }

        public async Task<T> UpdateAsync(int id, T entity)
        {

            entity.Id = id;
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            T entity = await _dbContext.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
