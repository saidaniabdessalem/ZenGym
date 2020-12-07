using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenGym.Domain;
using ZenGym.Domain.Entities;

namespace ZenGym.Persistence.EntityConfiguration
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.IsActive).HasDefaultValue(true);

        }
    }
}
