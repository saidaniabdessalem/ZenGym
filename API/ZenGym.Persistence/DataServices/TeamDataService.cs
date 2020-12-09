using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZenGym.Domain.Entities;
using ZenGym.Domain.Services;
using ZenGym.Persistence.DataServices.Common;

namespace ZenGym.Persistence.DataServices
{
    public class TeamDataService : ITeamDataService
    {
        private readonly ZenGymDbContext _dbContext;
        private readonly NonQueryDataService<Team> _nonQueryDataService;

        public TeamDataService(ZenGymDbContext dbContext, NonQueryDataService<Team> nonQueryDataService)
        {
            _dbContext = dbContext;
            _nonQueryDataService = nonQueryDataService;
        }

        public async Task<Team> CreateAsync(Team team)
        {
          return  await  _nonQueryDataService.CreateAsync(team);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _nonQueryDataService.DeleteAsync(id);
        }

        public async Task<Team> GetAsync(int id)
        {
            Team team = await _dbContext.Teams.FirstOrDefaultAsync(e => e.Id == id);
            return team;
        }

        public async Task<List<Team>> GetAllAsync()
        {
            List<Team> teams = await _dbContext.Teams
                                            .ToListAsync();
            return teams;
        }

        public async Task<Team> UpdateAsync(int id, Team team)
        {
            return await _nonQueryDataService.UpdateAsync(id,team);
        }
    }
}
