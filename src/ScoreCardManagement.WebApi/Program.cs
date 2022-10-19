global using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ScoreCardManagement.Common.Data;
using ScoreCardManagement.Common.Entities;
using ScoreCardManagement.WebApi.Mapper;
using ScoreCardManagement.WebApi.Service.Implementation;
using ScoreCardManagement.WebApi.Service.Interface;
//using ScoreCardManagement.WebApi.Validators;
using FluentValidation.AspNetCore;
using ScoreCardManagement.WebApi.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PlayerContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString")));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddTransient<IPlayerService, PlayerService>();
builder.Services.AddTransient<ScoreCardManagement.Common.Repository.Interface.IPlayerRepository, ScoreCardManagement.Common.Repository.Implementation.PlayerRepository>();

builder.Services.AddTransient<IOverService, OverService>();
builder.Services.AddTransient<ScoreCardManagement.Common.Repository.Interface.IOverRepository, ScoreCardManagement.Common.Repository.Implementation.OverRepository>();

builder.Services.AddTransient<ITeamService, TeamService>();
builder.Services.AddTransient<ScoreCardManagement.Common.Repository.Interface.ITeamRepository, ScoreCardManagement.Common.Repository.Implementation.TeamRepository>();

builder.Services.AddTransient<ITournamentService, TournamentService>();
builder.Services.AddTransient<ScoreCardManagement.Common.Repository.Interface.ITournamentRepository, ScoreCardManagement.Common.Repository.Implementation.TournamentRepository>();

builder.Services.AddTransient<IMatchService, MatchService>();
builder.Services.AddTransient<ScoreCardManagement.Common.Repository.Interface.IMatchRepository, ScoreCardManagement.Common.Repository.Implementation.MatchRepository>();

// builder.Services.AddTransient<IUserService, UserService>();
// builder.Services.AddTransient<ScoreCardManagement.Common.Repository.Interface.IUserRepository, ScoreCardManagement.Common.Repository.Implementation.UserRepository>();

var mapperConfig = new MapperConfiguration(mc =>
     {
         mc.AddProfile(new MappingProfile());
     });

     IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddFluentValidation(config =>
    {
        config.RegisterValidatorsFromAssemblyContaining<MatchValidator>();
         config.RegisterValidatorsFromAssemblyContaining<PlayerValidator>();
         config.RegisterValidatorsFromAssemblyContaining<OverValidator>();
         config.RegisterValidatorsFromAssemblyContaining<TeamValidator>();
         config.RegisterValidatorsFromAssemblyContaining<TournamentValidator>();
    });
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
