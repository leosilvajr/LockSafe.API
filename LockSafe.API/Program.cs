using LockSafe.Application.Services;
using LockSafe.Application.Services.Interface;
using LockSafe.Infra.Context;
using LockSafe.Infra.Repositories;
using LockSafe.Infra.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar o DbContext com SQL Server
builder.Services.AddDbContext<LockSafeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Injeção de Dependências

// Serviços
builder.Services.AddScoped<IUserService, UserService>();

// Repositórios
builder.Services.AddScoped<IUserRepository, UserRepository>();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
