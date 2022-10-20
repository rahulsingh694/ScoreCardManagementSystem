global using Microsoft.EntityFrameworkCore;
using System.Text;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
//using ScoreCardManagement.Auth.Mapper;
using ScoreCardManagement.Auth.Service.Implementation;
using ScoreCardManagement.Auth.Service.Interface;
using ScoreCardManagement.Auth.Validator;
using ScoreCardManagement.Common.Data;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PlayerContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<ScoreCardManagement.Common.Repository.Interface.IUserRepository, ScoreCardManagement.Common.Repository.Implementation.UserRepository>();

builder.Services.AddTransient<IUserService, UserService>();
//builder.Services.AddTransient<ScoreCardManagement.Common.Repository.Interface.IUserRepository, ScoreCardManagement.Common.Repository.Implementation.UserRepository>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

        
        
 
 builder.Services.AddFluentValidation(config =>
    {
        config.RegisterValidatorsFromAssemblyContaining<UserValidator>();
    });

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
 });
options.OperationFilter<SecurityRequirementsOperationFilter>();

});

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
