global using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using WebAPI4.Data;
using WebAPI4.Service;
using WebAPI4.Service.Impl;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

// Add services to the container.
// Fix ALL NOT REQUIRED properties.
builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("EmployeeDB")));
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", b =>
    b.AllowAnyMethod()
    .AllowAnyHeader()
    .AllowAnyOrigin());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();

