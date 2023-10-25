using Microsoft.EntityFrameworkCore;
using ScriptShoes.Domain;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Domain.Entities.Common;

namespace ScriptShoes.Persistence.Database;

public class AppDbContext : DbContext
{
    private readonly bool _isInMemory;
    public AppDbContext(DbContextOptions<AppDbContext> options, bool isInMemory = false) : base(options)
    {
        _isInMemory = isInMemory;
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Shoe> Shoes { get; set; }
    public DbSet<EmailCode> EmailCodes { get; set; }    
    public DbSet<Review> Reviews { get; set; }
    public DbSet<ReviewLike> ReviewsLikes { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Favorite> Favorites { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (_isInMemory)
        {
            modelBuilder
                .Entity<Shoe>().Property(e => e.ShoeSizes)
                .HasConversion(
                    v => new ArrayWrapper<List<float>>(v),
                    v => v.Values);
            
            modelBuilder
                .Entity<Shoe>().Property(e => e.Images)
                .HasConversion(
                    v => new ArrayWrapper<List<string>>(v),
                    v => v.Values);
        }
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    
    private struct ArrayWrapper<T>
    {
        public ArrayWrapper(T values)
            => Values = values;

        public T Values { get; }
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                     .Where(q => q.State is EntityState.Added or EntityState.Modified))
        {
            entry.Entity.LastModified = DateTime.UtcNow;

            if (entry.State == EntityState.Added)
                entry.Entity.Created = DateTime.UtcNow;
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}