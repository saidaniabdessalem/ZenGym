using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using ZenGym.Domain;
using ZenGym.Domain.Entities;

namespace ZenGym.Persistence.EntityConfiguration
{
    public class PointingEntityConfiguration : IEntityTypeConfiguration<Pointing>
    {

        public void Configure(EntityTypeBuilder<Pointing> builder)
        {
            builder.Property(p => p.EntryTime).HasDefaultValue(DateTime.Now);

        }
    }
}
