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
        private readonly ZenGymDbContext _dbContext;

        public NonQueryDataService(ZenGymDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> CreateAsync(T entity)
        {
            using ZenGymDbContext context = _dbContext;
            EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return createdResult.Entity;
        }

        public async Task<T> UpdateAsync(int id, T entity)
        {
            using ZenGymDbContext context = _dbContext;
            entity.Id = id;
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using ZenGymDbContext context = _dbContext;
            T entity = await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
