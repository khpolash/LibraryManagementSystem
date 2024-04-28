using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static LMS.SharedKernel.Entities.Identities.IdentityModel;

namespace LMS.Infrastructure.Persistence.Configurations.IdentityModelConfiguration;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder) { builder.ToTable(nameof(UserRole)); }
}
