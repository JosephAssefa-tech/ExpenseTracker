using System.Reflection;
using ExpenseTrackerApplicationLayer.Contracts.RepositoryInterface.Users;
using ExpenseTrackerApplicationLayer.Contracts.ServiceInterface.Users;
using ExpenseTrackerApplicationLayer.Models.Users.AutoMapper;
using ExpenseTrackerApplicationLayer.Models.Users.CommandHandlers;
using ExpenseTrackerApplicationLayer.Models.Users.Services;
using ExpenseTrackerApplicationPersistance;
using ExpenseTrackerApplicationPersistance.Repositories.Users;
using ExpenseTrackerIdentity;
using ExpenseTrackerIdentity.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ExpenseTrackerApplicationLayer.Contracts.RepositoryInterface.Budgets;
using ExpenseTrackerApplicationPersistance.Repositories.Budgets;
using ExpenseTrackerApplicationLayer.Contracts.ServiceInterface.Budgets;
using ExpenseTrackerApplicationLayer.Models.Budgets.Services;
using ExpenseTrackerApplicationLayer.Models.Budgets.AutoMapper;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext for Identity and Main Application (Expense Tracker)
builder.Services.AddDbContext<ExpenseTrackerIdentityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));

builder.Services.AddDbContext<ExpenseTrackerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Add Identity services (ApplicationUser and IdentityRole)
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ExpenseTrackerIdentityDbContext>()
    .AddDefaultTokenProviders();

// Register services
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBudgetRepository, BudgetRepository>();
builder.Services.AddScoped<IBudgetService, BudgetService>();

// Register AutoMapper and the UserProfile
builder.Services.AddAutoMapper(typeof(UserMappingProfile));
builder.Services.AddAutoMapper(typeof(BudgetMappingProfile));

// Register MediatR
builder.Services.AddMediatR(typeof(ExpenseTrackerApplicationLayer.Models.Users.CommandHandlers.CreateUserCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(ExpenseTrackerApplicationLayer.Models.Users.QueriesHandlers.GetAllUsersQueryHandler).Assembly);
builder.Services.AddMediatR(typeof(ExpenseTrackerApplicationLayer.Models.Budgets.CommandHandlers.CreateBudgetCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(ExpenseTrackerApplicationLayer.Models.Budgets.QueriesHandlers.GetALLBudgetQueryHandler).Assembly);

// JWT Authentication Configuration
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var key = builder.Configuration["JwtSettings:SecretKey"]; // Get the secret key from appsettings.json or another secure location
    var issuer = builder.Configuration["JwtSettings:Issuer"]; // Get the JWT issuer
    var audience = builder.Configuration["JwtSettings:Audience"]; // Get the JWT audience

    options.SaveToken = true; // Optional: saves the JWT token to the AuthenticationProperties
    options.RequireHttpsMetadata = false; // Set to true in production for HTTPS
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)) // Use the secret key to sign the JWT
    };
});

// Register Controllers
builder.Services.AddControllers();

// Register Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    // Add JWT Bearer authentication to Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Description = "Enter 'Bearer' followed by a space and the JWT token"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

var app = builder.Build();


// Seed roles and default admin user
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    // Call the methods to seed roles and default admin user
    await SeedRolesAsync(services);
    await SeedDefaultAdminAsync(services);
}

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

// Authentication and Authorization Middleware
app.UseAuthentication();  // Add authentication middleware
app.UseAuthorization();   // Add authorization middleware

app.MapControllers();

app.Run();

// Method to seed roles
async Task SeedRolesAsync(IServiceProvider serviceProvider)
{
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    // List of roles to seed
    var roles = new[] { "Admin", "User", "Manager" }; // Add more roles as needed

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

// Method to seed a default admin user
async Task SeedDefaultAdminAsync(IServiceProvider serviceProvider)
{
    var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    // Admin user details
    var adminEmail = "admin@example.com";
    var adminPassword = "Admin@123"; // Replace with a secure password in production

    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        // Create the admin user
        var user = new ApplicationUser { UserName = adminEmail, Email = adminEmail };
        var result = await userManager.CreateAsync(user, adminPassword);
        if (result.Succeeded)
        {
            // Assign the Admin role
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}
