using BsdFinalProject.Data;
using BsdFinalProject.Repositories;
using BsdFinalProject.Services;
using FinalProject.Repositories;
using FinalProject.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

//builder.Services.AddSwaggerGen(options =>
//{
//options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//{
//    Name = "Authorization",
//    Type = SecuritySchemeType.Http,
//    Scheme = "Bearer",
//    BearerFormat = "JWT",
//    In = ParameterLocation.Header,
//    Description = "Enter your JWT token in the format: Bearer {token}"
//});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// register repo + service
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();

builder.Services.AddScoped<GiftService>();
builder.Services.AddScoped<GiftRepository>();

builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<CategoryService>();

builder.Services.AddScoped<DonorRepository>();
builder.Services.AddScoped<DonorService>();

builder.Services.AddScoped<WinnerRepository>();
builder.Services.AddScoped<WinnerService>();

builder.Services.AddScoped<CardService>();
builder.Services.AddScoped<CardRepository>();

builder.Services.AddScoped<BasketService>();
builder.Services.AddScoped<BasketRepository>();

// DbContext
builder.Services.AddDbContext<SaleContext>(options =>
    options.UseSqlServer("Server=Srv2\\pupils;DataBase=Project0583255125;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=True;"));

// JWT configuration example: put these values in appsettings.json in production
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

app.UseHttpsRedirection();      

app.UseRouting();

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
