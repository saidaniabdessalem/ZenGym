using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenGym.Domain;
using ZenGym.Domain.Entities;

namespace ZenGym.Persistence.EntityConfiguration
{
    public class SubscriptionEntityConfiguration : IEntityTypeConfiguration<Subscription>
    {

        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.Property(p => p.IsCanceled).HasDefaultValue(false);

        }
    }
}
