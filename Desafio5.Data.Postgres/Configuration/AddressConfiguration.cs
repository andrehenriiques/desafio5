using Desafio5.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio5.Data.Postgres.Configuration;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Address");

        builder.HasKey(e => e.ID);
        
        builder.HasOne(a => a.Client)
            .WithOne(c => c.Address)
            .HasForeignKey<Client>(c => c.AddressId);
    }
}