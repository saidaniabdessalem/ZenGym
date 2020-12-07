using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZenGym.Domain;
using ZenGym.Domain.Entities;
using ZenGym.Domain.Services;
using ZenGym.Persistence;
using ZenGym.Persistence.DataServices.Common;

namespace ZenGym.Persistence.DataServices
{
    public class MemberDataService: IMemberDataService
    {
        private readonly ZenGymDbContext _dbContext;
        private readonly NonQueryDataService<Member> _nonQueryDataService;

        public MemberDataService(ZenGymDbContext dbContext, NonQueryDataService<Member> nonQueryDataService)
        {
            _dbContext = dbContext;
            _nonQueryDataService = nonQueryDataService;
        }

        public async Task<Member> CreateAsync(Member member)
        {
            return await _nonQueryDataService.CreateAsync(member);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _nonQueryDataService.DeleteAsync(id);
        }
        public async Task<Member> UpdateAsync(int id, Member member)
        {
            return await _nonQueryDataService.UpdateAsync(id, member);
        }

        public async Task<Member> GetAsync(int id)
        {
            using ZenGymDbContext context = _dbContext;
            Member member = await context.Members
                                            .Include(t => t.Team)
                                            .FirstOrDefaultAsync(e => e.Id == id);
            return member;
        }

        public async Task<List<Member>> GetAllAsync()
        {
            using ZenGymDbContext context = _dbContext;
            List<Member> members = await context.Members
                                                .Include(t => t.Team)
                                                .ToListAsync();
            return members;
        }


    }
}

