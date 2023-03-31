using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using Services;

var builder = WebApplication.CreateBuilder(args);

//Add Connection String From AppSettings
var conString = builder.Configuration.GetConnectionString("Company");

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add DBContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(conString));

//Add Services For Injections
builder.Services.ServiceLibrary();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// add swagger for production 
else if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());
app.UseAuthorization();

app.MapControllers();

app.Run();
