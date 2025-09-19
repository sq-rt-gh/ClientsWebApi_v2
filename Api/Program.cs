using ClientsWebApi_v2.Application.Interfaces.Repositories;
using ClientsWebApi_v2.Application.Interfaces.Services;
using ClientsWebApi_v2.Application.Services;
using ClientsWebApi_v2.Infrastructure;
using ClientsWebApi_v2.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ClientsDb;Trusted_Connection=True;"));

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IFounderRepository, FounderRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IFounderService, FounderService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();