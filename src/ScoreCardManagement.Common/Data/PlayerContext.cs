using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScoreCardManagement.Common.Entities;
namespace ScoreCardManagement.Common.Data
{
    public class PlayerContext :DbContext
    {
        public PlayerContext(DbContextOptions<PlayerContext> options) :base(options)
        {
            
        }
        public DbSet<Player> Players {get; set;} 
        public DbSet<Over> Overs {get; set;}
        public DbSet<Team> Teams {get; set;}
        public DbSet<Tournament> Tournaments {get; set;}
        public DbSet<Match> Matches {get; set;}
        public DbSet<User> Users { get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().HasKey(c=>c.PlayerId);
            modelBuilder.Entity<Over>().HasKey(c=>c.OverId);
            modelBuilder.Entity<Team>().HasKey(c=>c.TeamId);
            modelBuilder.Entity<Tournament>().HasKey(c=>new {c.TournamentId});
            modelBuilder.Entity<Match>().HasKey(c=>c.MatchId);
            modelBuilder.Entity<User>().HasKey(c=>c.UserId); 
        }
    }

 }
