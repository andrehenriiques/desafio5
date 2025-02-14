using Desafio5.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio5.Data.Postgres.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Order");

        builder.HasKey(e => e.ID);
        
        builder
            .HasOne(e => e.Client)       
            .WithMany(l => l.Order)            
            .HasForeignKey(e => e.ClientId)     
            .OnDelete(DeleteBehavior.Cascade);   

        builder
            .HasMany(e => e.Product)       
            .WithMany(l => l.Order);   
    }
}