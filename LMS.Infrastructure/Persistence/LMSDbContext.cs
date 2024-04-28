using LMS.Infrastructure.Persistence.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static LMS.SharedKernel.Entities.Identities.IdentityModel;

namespace LMS.Infrastructure.Persistence;

public class LMSDbContext(DbContextOptions<LMSDbContext> options, ILoggerFactory loggerFactory) : IdentityDbContext<User, Role, long, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>(options)
{
    private readonly ILoggerFactory _loggerFactory = loggerFactory;

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    { return await base.SaveChangesAsync(cancellationToken); }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseLoggerFactory(_loggerFactory);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ILMSContext).Assembly);
        builder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys())
            .ToList().ForEach(x => x.DeleteBehavior = DeleteBehavior.Restrict);
    }
}
