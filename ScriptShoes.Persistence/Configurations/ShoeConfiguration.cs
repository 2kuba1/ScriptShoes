using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScriptShoes.Domain;

namespace ScriptShoes.Persistence.Configurations;

public class ShoeConfiguration : IEntityTypeConfiguration<Shoe>
{
    public void Configure(EntityTypeBuilder<Shoe> builder)
    {
        builder.HasNoKey()
            .Property(x => x.ShoeSizes);  
        
        builder.HasNoKey()
            .Property(x => x.Images);
    }
}