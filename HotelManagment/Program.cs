using FluentValidation;
using HotelManagment.Application.Common.Validators;
using HotelManagment.Application.Configurations;
using HotelManagment.Application.Interfaces;
using HotelManagment.Application.Services;
using HotelManagment.Configurations;
using HotelManagment.Data.DbContexts;
using HotelManagment.Data.Interfaces;
using HotelManagment.Data.Repositories;
using HotelManagment.Domain.Entities;
using HotelManagment.Middlewares;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();
// Serilog
builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));

// Db Context
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDb"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

//UnitOfWork
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

//Services
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IAuthManager, AuthManager>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IHotelService, HotelService>();
builder.Services.AddTransient<IRoomService, RoomService>();
builder.Services.AddTransient<IEmailService, EmailService>();

// Configure
builder.Services.ConfigureJwtAuthorize(builder.Configuration);
builder.Services.ConfigureSwaggerAuthorize(builder.Configuration);

//Validators
builder.Services.AddScoped<IValidator<User>, UserValidator>();
builder.Services.AddScoped<IValidator<Hotel>, HotelValidator>();
builder.Services.AddScoped<IValidator<Room>, RoomValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<ExceptionsHadle>();

app.MapControllers();

app.Run();
