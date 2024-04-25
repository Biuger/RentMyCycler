using Dapper.Contrib.Extensions;
using RentMyCycler.Api.DataAccess;
using RentMyCycler.Api.DataAccess.Interfaces;
using RentMyCycler.Api.Repositories;
using RentMyCycler.Api.Repositories.Interfaces;
using RentMyCycler.Api.Services;
using RentMyCycler.Api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBikeCategoryRepository, BikeCategoryRepository>();
builder.Services.AddScoped<IBikeCategoryService, BikeCategoryService>();

builder.Services.AddScoped<IBikeRepository, BikeRepository>();
builder.Services.AddScoped<IBikeService, BikeService>();

builder.Services.AddScoped<IReserveRepository, ReserveRepository>();
builder.Services.AddScoped<IReserveService, ReserveService>(); 

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

builder.Services.AddScoped<IRentalHistoryRepository, RentalHistoryRepository>();
builder.Services.AddScoped<IRentalHistoryService, RentalHistoryService>();

builder.Services.AddScoped<IUsageStatisticsRepository, UsageStatisticsRepository>();
builder.Services.AddScoped<IUsageStatisticsService, UsageStatisticsService>();

builder.Services.AddScoped<IDbContext, DbContext>();

var app = builder.Build();

SqlMapperExtensions.TableNameMapper = entityType =>
{
    var name = entityType.ToString();
    if (name.Contains("RentMyCycler.Core.Entities."))
    name = name.Replace("RentMyCycler.Core.Entities.", "");
    var letters = name.ToCharArray();
    letters[0] = char.ToUpper(letters[0]);
    return new string(letters);
};

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