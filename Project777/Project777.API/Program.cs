using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
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

builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Project 777 API", Version = "V1" });
    options.UseInlineDefinitionsForEnums();


    var apiXmlFile = Path.Combine(AppContext.BaseDirectory, "Project777.API.xml");
    var modelsXmlFile = Path.Combine(AppContext.BaseDirectory, "Project777.Models.xml");
    options.IncludeXmlComments(apiXmlFile);
    options.IncludeXmlComments(modelsXmlFile);


    //adds the ability to enter a bearer token when excuting commands using the SwaggerUI
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter your token in the text input below.\r\n\r\nExample: \"12345abcdef\"",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },

                },
            new string[]{}
            }
        });
}
);

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


//runs equivalent of Update-Database each time the program starts
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

// Allow hosting of static web pages
if (!app.Environment.IsProduction())
{
    app.UseDefaultFiles();  // Allows index.html, index.js, etc. files to be opened without specifying their name in the url
    app.UseStaticFiles();   // Enables the app to host .html pages, etc.
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
