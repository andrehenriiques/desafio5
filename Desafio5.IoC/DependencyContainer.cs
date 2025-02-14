
using Desafio5.Application.Services;
using Microsoft.EntityFrameworkCore;
using Desafio5.Data.Postgres.Context;
using Desafio5.Data.Postgres.Repository;
using Desafio5.Domain.Interfaces.Repository;
using Desafio5.Data.Repository;
using Desafio5.Domain.Interfaces.Repository;
using Desafio5.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Desafio5.IoC;

public class DependencyContainer
{
    public static void RegisterServices(IServiceCollection services,string? postGresConnectionString, ConfigurationManager configuration)
    {
        //Context
        services.AddDbContext<PostgresDbContext>(options =>
        {
            if (postGresConnectionString != null)
            {
                options
                    .UseNpgsql(postGresConnectionString);
            }
        });
        //Services
        services.AddScoped<IClientService,ClientService>();
        //Queues
        //Extensions        
        //Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        //Repositorys
	}
}