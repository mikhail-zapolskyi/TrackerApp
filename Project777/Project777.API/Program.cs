using Microsoft.EntityFrameworkCore;
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

app.UseAuthorization();

app.MapControllers();

app.Run();
