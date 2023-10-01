using Microsoft.EntityFrameworkCore;
using ScriptShoes.Domain;
using ScriptShoes.Domain.Common;

namespace ScriptShoes.Persistence.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Shoe> Shoes { get; set; }
    public DbSet<EmailCode> EmailCodes { get; set; }    
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Favorite> Favorites { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                     .Where(q => q.State is EntityState.Added or EntityState.Modified))
        {
            entry.Entity.LastModified = DateTime.Now;

            if (entry.State == EntityState.Added)
                entry.Entity.Created = DateTime.Now;
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}