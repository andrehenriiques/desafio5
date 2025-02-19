

using Desafio5.MsgContracts.Command;

using MassTransit;
using Desafio5.Application.Services;
using Microsoft.EntityFrameworkCore;
using Desafio5.Data.Postgres.Context;
using Desafio5.Domain.Interfaces.Repository;
using Desafio5.Data.Repository;
using Desafio5.Domain.Interfaces.Services;
using Desafio5.MsgContracts.Interface;
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
        
        services.AddMassTransit(x =>
        {
            x.AddConsumer<ClientCommand>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("rabbitmq://localhost", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ReceiveEndpoint("create-client", e =>
                {
                    e.ConfigureConsumer<ClientCommand>(context);
                });
            });
        });

        //EndPointConvention
        //Extensions        
        //Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        //Repositorys
	}
}