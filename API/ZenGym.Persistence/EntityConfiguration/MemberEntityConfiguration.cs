using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenGym.Domain;
using ZenGym.Domain.Entities;

namespace ZenGym.Persistence.EntityConfiguration
{
    public class MemberEntityConfiguration : IEntityTypeConfiguration<Member>
    {

        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(p => p.IsActive).HasDefaultValue(true);
       
        }
    }
}
