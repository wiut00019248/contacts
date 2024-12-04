using Microsoft.EntityFrameworkCore;
using Web.CW._19248.Data;
using Web.CW._19248.Mapping;
using Web.CW._19248.Models;
using Web.CW._19248.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin() 
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Mapping));
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

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
