using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static LMS.SharedKernel.Entities.Identities.IdentityModel;

namespace LMS.Infrastructure.Persistence.Configurations.IdentityModelConfiguration;

public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.ToTable(nameof(UserToken));
        builder.Property(x => x.Name).HasMaxLength(85);
        builder.Property(x => x.LoginProvider).HasMaxLength(85);
    }
}
