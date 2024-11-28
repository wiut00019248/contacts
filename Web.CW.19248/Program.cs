using Microsoft.EntityFrameworkCore;
using Web.CW._19248.Data;
using Web.CW._19248.MappingProfiles;
using Web.CW._19248.Models;
using Web.CW._19248.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MappingProfile));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("SqlServerConnection");
builder.Services.AddDbContext<GeneralDbContext>(opts => opts.UseSqlServer(connectionString));
builder.Services.AddScoped<IRepository<Contact>, ContactRepository>();

builder.Services.AddTransient<IRepository<Contact>, ContactRepository>();
builder.Services.AddTransient<IRepository<Category>, CategoryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
