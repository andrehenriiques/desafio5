using Desafio5.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio5.Data.Postgres.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");

        builder.HasKey(e => e.ID);
     
        builder
            .HasMany(e => e.Order)       
            .WithMany(l => l.Product);   
    }
}