using System.Reflection;
using ExpenseTrackerApplicationLayer.Contracts.RepositoryInterface.Users;
using ExpenseTrackerApplicationLayer.Contracts.ServiceInterface.Users;
using ExpenseTrackerApplicationLayer.Models.Users.AutoMapper;
using ExpenseTrackerApplicationLayer.Models.Users.CommandHandlers;
using ExpenseTrackerApplicationLayer.Models.Users.Services;
using ExpenseTrackerApplicationPersistance;
using ExpenseTrackerApplicationPersistance.Repositories.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext
builder.Services.AddDbContext<ExpenseTrackerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Register services
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// Register AutoMapper and the UserProfile
builder.Services.AddAutoMapper(typeof(UserMappingProfile)); 

// Register MediatR
builder.Services.AddMediatR(typeof(ExpenseTrackerApplicationLayer.Models.Users.CommandHandlers.CreateUserCommandHandler).Assembly);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure Swagger middleware for Development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Expense Tracker API v1");
        options.RoutePrefix = string.Empty; // Swagger available at root URL
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
