using Microsoft.EntityFrameworkCore;
using SchoolApp.Core;
using SchoolApp.Infrastructure;
using SchoolApp.Infrastructure.Context;
using SchoolApp.Service;
using System;
using Microsoft.AspNetCore.Builder;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
});
#region Dependancy Injection
builder.Services.AddInfrastructureDependencies()
                .AddServiceDependencies()
                .AddCoreDependencies();
#endregion
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = ""; // عشان تفتح Swagger على الرابط الأساسي
});



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
