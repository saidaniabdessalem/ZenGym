using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZenGym.Domain.Entities;
using ZenGym.Domain.Services;
using ZenGym.Persistence.DataServices.Common;

namespace ZenGym.Persistence.DataServices
{
    public class UserDataService : IUserDataService
    {

        private readonly ZenGymDbContext _dbContext;
        private readonly NonQueryDataService<User> _nonQueryDataService;

        public UserDataService(ZenGymDbContext dbContext, NonQueryDataService<User> nonQueryDataService)
        {
            _dbContext = dbContext;
            _nonQueryDataService = nonQueryDataService;
        }

        public async Task<User> CreateAsync(User user)
        {
            return await _nonQueryDataService.CreateAsync(user);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _nonQueryDataService.DeleteAsync(id);
        }
        public async Task<User> UpdateAsync(int id, User user)
        {
            return await _nonQueryDataService.UpdateAsync(id, user);
        }

        public async Task<User> GetAsync(int id)
        {
            User user = await _dbContext.Users.FirstOrDefaultAsync(e => e.Id == id);
            return user;
        }

        public async Task<List<User>> GetAllAsync()
        {
            List<User> members = await _dbContext.Users.ToListAsync();
            return members;
        }

        public async Task<User> GetByUsername(string username)
        {
            User user = await _dbContext.Users.FirstOrDefaultAsync(e => e.UserName == username);
            return user;
        }

        public async Task<bool> IsUserExist(string username)
        {
            return await _dbContext.Users.AnyAsync(x => x.UserName == username);
        }
    }
}