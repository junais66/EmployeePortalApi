using EmloyeePortal.Data;
using EmloyeePortal.Respositories;
using EmloyeePortal.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EmpDbContex>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")), ServiceLifetime.Scoped);


_ = builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//AddServiceDependancy
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();

