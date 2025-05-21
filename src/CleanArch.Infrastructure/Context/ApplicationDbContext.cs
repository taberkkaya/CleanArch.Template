using CleanArch.Domain.Abstractions;
using CleanArch.Domain.Employees;
using CleanArch.Domain.Users;
using GenericRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Context;

internal sealed class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        modelBuilder.Ignore<IdentityUserClaim<Guid>>();
        modelBuilder.Ignore<IdentityRoleClaim<Guid>>();
        modelBuilder.Ignore<IdentityUserRole<Guid>>();
        modelBuilder.Ignore<IdentityUserToken<Guid>>();
        modelBuilder.Ignore<IdentityUserLogin<Guid>>();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<Entity>();

        HttpContextAccessor httpContextAccessor = new();
        Guid userId = Guid.Parse(httpContextAccessor
            .HttpContext!
            .User
            .Claims
            .First(p => p.Type == "user-id").Value);

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property(p => p.CreatedAt)
                    .CurrentValue = DateTimeOffset.Now;
                entry.Property(p => p.CreatedBy)
                    .CurrentValue = userId;
            }

            if (entry.State == EntityState.Modified)
            {

                if (entry.Property(p => p.IsDeleted).CurrentValue == true)
                {
                    entry.Property(p => p.DeletedAt)
                        .CurrentValue = DateTimeOffset.Now;
                    entry.Property(p => p.DeletedBy)
                        .CurrentValue = userId;
                }

                else
                {
                    entry.Property(p => p.UpdatedAt)
                        .CurrentValue = DateTimeOffset.Now;
                    entry.Property(p => p.UpdatedBy)
                        .CurrentValue = userId;
                }
            }

            if (entry.State == EntityState.Deleted)
                throw new ArgumentException("Database üzerinden hard delete yapamazsınız.");
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
