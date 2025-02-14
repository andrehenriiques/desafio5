using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Desafio5.Data.Postgres.Context
{
    public class PostgresDbContext : DbContext
    {
        public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options) { }

       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       {
           if (!optionsBuilder.IsConfigured)
           {
               var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
               var configuration = new ConfigurationBuilder()
                   .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Desafio5.Api"))
                   .AddJsonFile("appsettings.json")
                   .AddJsonFile($"appsettings.{environment}.json", optional: true)
                   .Build();

               var connectionString = configuration.GetConnectionString("DatabasePostGres");

               optionsBuilder.UseNpgsql(connectionString);
           }
       }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Cascade;
            }
            
            base.OnModelCreating(modelBuilder);
            
        }
    }
}