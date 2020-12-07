using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenGym.Domain;
using ZenGym.Domain.Entities;

namespace ZenGym.Persistence.EntityConfiguration
{
    public class SubscriptionTypeEntityConfiguration : IEntityTypeConfiguration<SubscriptionType>
    {

        public void Configure(EntityTypeBuilder<SubscriptionType> builder)
        {
            builder.Property(p => p.IsActive).HasDefaultValue(true);

        }
    }
}
