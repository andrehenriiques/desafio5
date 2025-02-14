using Desafio5.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio5.Data.Postgres.Configuration;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Client");

        builder.HasKey(e => e.ID);
     
        builder
            .HasMany(l => l.Order) 
            .WithOne(i => i.Client)    
            .HasForeignKey(i => i.ClientId) 
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasMany(l => l.Order) 
            .WithOne(i => i.Client)    
            .HasForeignKey(i => i.ClientId) 
            .OnDelete(DeleteBehavior.Cascade); 
    }
}