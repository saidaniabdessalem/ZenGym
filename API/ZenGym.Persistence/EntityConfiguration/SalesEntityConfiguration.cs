using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenGym.Domain;
using ZenGym.Domain.Entities;

namespace ZenGym.Persistence.EntityConfiguration
{
    public class SalesEntityConfiguration : IEntityTypeConfiguration<Sale>
    {

        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.Property(p => p.IsDeteted).HasDefaultValue(false);

        }
    }
}
