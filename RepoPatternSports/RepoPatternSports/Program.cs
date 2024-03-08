using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RepoPatternSports.Repository;
using RepoPatternSports.Repository.Interface;
using RepoPatternSports.Repository.Repository;
using RepoPatternSports.Service.Interface;
using RepoPatternSports.Service.Service;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
    };

});

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MyCon")), ServiceLifetime.Scoped);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OnlineTest", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your Bearer in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                    });
});

builder.Services.AddScoped<IAuthRepo, AuthRepo>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<ICoachRepo, CoachRepo>();
builder.Services.AddScoped<ICoachService, CoachService>();

builder.Services.AddScoped<ICaptainRepo, CaptainRepo>();
builder.Services.AddScoped<ICaptainService, CaptainService>();

builder.Services.AddScoped<IPlayerRepo, PlayerRepo>();
builder.Services.AddScoped<IPlayerService, PlayerService>();

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IPasswordHash, PasswordHash>();

builder.Services.AddScoped<IValidationService, ValidationService>();


builder.Services.AddTransient<IUserRepo, UserRepo>();

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
