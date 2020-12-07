using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Text;
using ZenGym.Domain.Common;
using ZenGym.Domain.Entities;
using ZenGym.Domain.Services;
using ZenGym.Persistence.DataServices;
using ZenGym.Persistence.DataServices.Common;

namespace ZenGym.Persistence
{
    public static class PersistenceDependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            //Team
            services.AddScoped<NonQueryDataService<Team>>();
            services.AddScoped<IDataService<Team>, TeamDataService>();
            services.AddScoped<ITeamDataService, TeamDataService>();

            //Member
            services.AddScoped<NonQueryDataService<Member>>();
            services.AddScoped<IDataService<Member>, MemberDataService>();
            services.AddScoped<IMemberDataService, MemberDataService>();

            return services;
        }
    }
}
