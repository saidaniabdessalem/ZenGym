using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenGym.Domain;
using ZenGym.Domain.Entities;

namespace ZenGym.Persistence.EntityConfiguration
{

    public class EntityConfiguration : IEntityTypeConfiguration<Team>
    {

        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);

        }
    }
}
