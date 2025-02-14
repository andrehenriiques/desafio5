using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
namespace Desafio5.Data.Postgres.Context
{
    public class PostgresDbContextFactory : IDesignTimeDbContextFactory<PostgresDbContext>
    {
        
        public PostgresDbContext CreateDbContext(string[] args)
        {
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
               var configuration = new ConfigurationBuilder()
                   .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Desafio5.Api"))
                   .AddJsonFile("appsettings.json")
                   .AddJsonFile($"appsettings.{environment}.json", optional: true)
                   .Build();

               var connectionString = configuration.GetConnectionString("DatabasePostGres");
            
            var dbContextBuilder = new DbContextOptionsBuilder<PostgresDbContext>();
            if (connectionString != null)
            {  
                dbContextBuilder.UseNpgsql(connectionString);          
              
                
            }
            return new PostgresDbContext(dbContextBuilder.Options);
        }
    }
}