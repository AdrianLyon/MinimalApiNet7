using BackEnd.Models;
using BackEnd.Modules;
using BackEnd.Services.Interfaces;
using BackEnd.Services.Repository;
using BackEnd.Utility;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MinimaldbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
});
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("NewPolicy", app =>
    {
        app.AllowAnyHeader()
           .AllowAnyMethod()
           .AllowAnyOrigin();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region Customer
app.AddCustomersEndPoints();
#endregion

#region Supplier
app.AddSupplierEndPoints();
#endregion

app.Run();
