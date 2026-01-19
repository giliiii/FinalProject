using BsdFinalProject.Data;
using BsdFinalProject.IRepositories;
using BsdFinalProject.IServices;
using BsdFinalProject.Repositories;
using BsdFinalProject.Services;
using FinalProject.Repositories;
using FinalProject.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.ComponentModel.DataAnnotations;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//cors
// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("allowlocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
//builder.Services.AddCors();


// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// Add services to the container.
builder.Host.UseSerilog();

builder.Services.AddControllers(options =>
{
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});



// Add repository and service registrations
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGiftService, GiftService>();
builder.Services.AddScoped<IGiftRepository, GiftRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IDonorRepository, DonorRepository>();
builder.Services.AddScoped<IDonorService, DonorService>();
builder.Services.AddScoped<IWinnerRepository, WinnerRepository>();
builder.Services.AddScoped<IWinnerService, WinnerService>();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();

// DbContext
builder.Services.AddDbContext<SaleContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));




    // JWT configuration
    var key = builder.Configuration["Jwt:Key"];
    if (!string.IsNullOrEmpty(key))
    {
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = !string.IsNullOrEmpty(builder.Configuration["Jwt:Issuer"]),
                ValidateAudience = !string.IsNullOrEmpty(builder.Configuration["Jwt:Audience"]),
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
            };
        });
    }

    var app = builder.Build();
app.UseCors("allowlocalhost");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // Swagger UI at app root
    });
}
//app.Use(async (context, next) =>
//{
//    if (context.Request.Method == "OPTIONS")
//    {
//        context.Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:4200");
//        context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");
//        context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
//        context.Response.StatusCode = 200;
//        await context.Response.CompleteAsync();
//        return;
//    }

//    await next();
//});
app.UseHttpsRedirection();
    app.UseRouting();

//app.UseCors(x => x
//    .AllowAnyOrigin()
//    .AllowAnyHeader()
//    .AllowAnyMethod()
//);

app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();


//namespace BsdFinalProject.DTOs
//{
//    public class CreateDonorDto
//    {
//        [Required, MaxLength(20)]
//        public string Name { get; set; }

//        [Required, EmailAddress, MaxLength(50)]
//        public string Email { get; set; }
//    }
//}
