using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using OnlineChatApp.Models;

var builder = WebApplication.CreateBuilder(args);

// var builder = WebApplication.CreateBuilder(new WebApplicationOptions
// {
//     EnvironmentName = Environments.Staging
// }); 

// Add services to the container.

builder.Services.AddControllers();
var connectionStrings = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<OnlineChatAppDb>(options => options.UseNpgsql(connectionStrings));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
