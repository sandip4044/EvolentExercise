using Evolent.Repository.Context;
using Evolent.Repository.Models;
using Evolent.Repository.Repository;
using Evolent.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Repository Registration
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
//Service Registration
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
//DB Context Registration
builder.Services.AddDbContext<EmployeeContext>();

//builder.Services.AddDbContext<EmployeeContext>(x => x.UseSqlServer(configuration.GetConnectionString("EvolentDb")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
