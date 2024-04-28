using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static LMS.SharedKernel.Entities.Identities.IdentityModel;

namespace LMS.Infrastructure.Persistence.Configurations.IdentityModelConfiguration;

public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
{
    public void Configure(EntityTypeBuilder<UserLogin> builder)
    {
        builder.ToTable(nameof(UserLogin));
        builder.Property(x => x.ProviderDisplayName).HasMaxLength(85);
        builder.Property(x => x.ProviderKey).HasMaxLength(85);
        builder.Property(x => x.LoginProvider).HasMaxLength(85);
    }
}
