using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Project777.Repositories;
using Project777.Repositories.Interfaces;
using Project777.Services;
using Project777.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Setup the database using the ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql( //connect to postgres db
        builder.Configuration.GetConnectionString("DefaultConnection"),
        npgsqlOptions =>
        {
            //configure what project we want to store our Code-First Migration in
            npgsqlOptions.MigrationsAssembly("Project777.Repositories");
        }
    ));

// Setup authentication
builder.Services.AddAuthentication(options =>
                {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.Authority = builder.Configuration.GetSection("Auth0").GetValue<string>("Domain");
                    options.Audience = builder.Configuration.GetSection("Auth0").GetValue<string>("Audience");
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        RoleClaimType = "http://schemas.project777.com/roles"
                    };
                });


builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
