using Application.Tasks.Commands;
using Microsoft.Extensions.Configuration;
using Persistence;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories;
using Persistence.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var connectionStringName = "TestTaskConnectionString";
// Add services to the container.
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(CreateListOfTasksCommand))));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString(connectionStringName)
                ));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IListOfTasksRepository, ListOfTasksRepository>();

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
