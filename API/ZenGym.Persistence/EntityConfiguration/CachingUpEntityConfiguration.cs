using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenGym.Domain;
using ZenGym.Domain.Entities;

namespace ZenGym.Persistence.EntityConfiguration
{
    public class CachingUpEntityConfiguration : IEntityTypeConfiguration<CachingUp>
    {
       
        public void Configure(EntityTypeBuilder<CachingUp> builder)
        {
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);
        }
    }
}
