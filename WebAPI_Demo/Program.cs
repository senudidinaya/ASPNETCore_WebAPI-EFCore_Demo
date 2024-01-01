using Microsoft.EntityFrameworkCore;
using WebAPI_Demo.Models;

var builder = WebApplication.CreateBuilder(args);

//Register your data context in your Program.cs file
//builder.Services.AddSqlServer<EmployeeContext>(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddDbContext<EmployeeContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
