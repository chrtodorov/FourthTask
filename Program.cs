using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Repositories;
using WebApplication1.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true, true).Build();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IShiftRepository, ShiftRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.MapControllers();

app.Run();