
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZenGym.Domain.Common;
using ZenGym.Domain.Services;
using ZenGym.Persistence;
using ZenGym.Persistence.DataServices.Common;

namespace ZenGym.Persistence.DataServices
{
    public class GenericDataService<T> : IDataService<T> where T : BaseEntity
    {
        private readonly ZenGymDbContext _dbContext;
        private readonly NonQueryDataService<T> _nonQueryDataService;

        public GenericDataService(ZenGymDbContext dbContext , NonQueryDataService<T> nonQueryDataService)
        {
            _dbContext = dbContext;
            _nonQueryDataService = nonQueryDataService;
        }

        public async Task<T> CreateAsync(T entity)
        {
          return   await _nonQueryDataService.CreateAsync(entity);
        }

        public async Task<T> UpdateAsync(int id, T entity)
        {
           return await _nonQueryDataService.UpdateAsync(id, entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _nonQueryDataService.DeleteAsync(id);
        }

        public async Task<T> GetAsync(int id)
        {
            using ZenGymDbContext context = _dbContext;
            T entity = await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        public async Task<List<T>> GetAllAsync()
        {
            using ZenGymDbContext context = _dbContext;
            List<T> entities = await context.Set<T>().ToListAsync();
            return entities;
        }

       
    }
}
