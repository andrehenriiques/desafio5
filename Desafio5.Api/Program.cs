
using Desafio5.Api.Filters;
using Desafio5.Application.Services;
using Desafio5.Data.Postgres.Repository;
using Desafio5.Domain.Interfaces.Repository;
using Desafio5.Domain.Interfaces.Services;
using Desafio5.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
DependencyContainer.RegisterServices(builder.Services, builder.Configuration.GetConnectionString("DatabasePostGres"), builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>().AddProblemDetails();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();  // Mapear os controladores
});

app.Run();
 