using ScoreCardManagement.Common.Entities;
using ScoreCardManagement.Common.Filters;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;

namespace ScoreCardManagement.Test.RepositoryTests
{
    [TestFixture]
    public class PlayerRepository : InMemoryDbContext
    {
        public readonly PlayerFilter playerFilter;
        public PlayerRepository()
        {
           playerFilter=new PlayerFilter();
        }

        [Test]
        public async Task AddPlayerAsync_NotNullPlayerWithParameters_ReturnNotthrowException()
        {
            // Arrange

            Player player = GetList()[0];
        
            var _playerRepository = new PlayerRepository(DbContext);

            // Act
            await _playerRepository.CreatePlayerAsync(player);
            var result = DbContext.Player.Where(c=>c.PlayerId == player.PlayerId).FirstOrDefault();

            //Assert
            Assert.AreEqual(result.PlayerId,player.PlayerId);
            Assert.AreEqual(result.PlayerName,player.PlayerName);
            Assert.AreEqual(result.PlayerTeam,player.PlayerTeam);
            Assert.AreEqual(result.PlayerCountry,player.PlayerCountry);
            Assert.AreEqual(result.PlayerAge,player.PlayerAge);
            Assert.AreEqual(result.PlayerType,player.PlayerType);
        }

        [Test]
        public async Task AddPlayerAsync_NullPlayer_ThrowsNullException()
        {
            //Arrange
            var _playerRepository = new PlayerRepository(DbContext);
            
            //Act
            //Assert
            Assert.ThrowsAsync<NullReferenceException>(() => _playerRepository.CreatePlayer(null));
        } 

        [Test]
        public async Task DeletePlayerAsync_ShouldDelete_ReturnTrue()
        {
            // Arrange
          //  DbContext.Employee.AddRange(GetList());
          //  DbContext.SaveChanges();
            Player player = GetList()[0];
            var _playerRepository = new PlayerRepository(DbContext);
            int playerId = player.PlayerId;

            // Act
             await _playerRepository.DeletePlayer(playerId);
             var result = DbContext.Player.Where(c=>c.PlayerId == player.PlayerId);  
            //Assert
            DbContext.Player.Where(c => c.PlayerId == playerId).Count().Should().Be(0);
        }

        [Test]
        public async Task DeletePlayerAsync_ShouldRollbackDelete_ReturnFalse()
        {
            // Arrange
            
            Player player = GetList()[0];
            var _playerRepository = new PlayerRepository(DbContext);
            int playerId = -10;

            // Act
            await _playerRepository.DeletePlayer(playerId);

            //Assert
            DbContext.Player.Where(c => c.PlayerId == playerId).Count().Should().Be(1);
        }

        [Test]
        public async Task UpdatePlayerAsync_ShouldUpdate_ReturnTrue()
        {
            //Arrange
           List<Player> lstplayer = new List<Player>();
            lstplayer.Add(new Player()
            {
                PlayerId=1,
                PlayerName="rahul",
                PlayerTeam="India",
                PlayerCountry="India",
                PlayerAge=35,
                PlayerType="Batsman"
            });
              var player=lstplayer[0];
              var _playerRepository = new PlayerRepository(DbContext);
             await _playerRepository.CreatePlayer(player);
             var playerFromDb = await _playerRepository.GetPlayer(player.PlayerId);
             playerFromDb.PlayerName = "sachin";

            // Act
             await _playerRepository.UpdatePlayer(playerFromDb);
             var result = DbContext.Player.Where(c=>c.PlayerId == player.PlayerId).FirstOrDefault();  
            
            //Assert
            
            Assert.IsNotNull(result);
            Assert.AreEqual(result.PlayerId,player.PlayerId);
            Assert.AreEqual(result.PlayerName,playerFromDb.PlayerName);
          
        }
 
        [Test]
        public async Task GetPlayerAsync_NotNullPlayerWithParameters_ReturnNotthrowException()
        {
            //Arrange
            int playerId = 1;
           
            DbContext.Player.AddRange(GetList());
            DbContext.SaveChanges();
            var _playerRepository = new PlayerRepository(DbContext);

            //Act
            var result = await _playerRepository.GetPlayer(playerId);

            //Asert
            Assert.AreEqual(result.PlayerId,playerId);

        }

        [Test]
        public async Task GetPlayerAsync_NullPlayer_ThrowsNullException()
        {
            //Arrange
            var _playerRepository = new PlayerRepository(DbContext);
            int playerId=-10;
            //Act
            //Assert
            Assert.ThrowsAsync<NullReferenceException>(() => _playerRepository.GetPlayer(playerId));
        }

        private List<Player> GetList()
        {
            List<Player> lstplayer = new List<Player>();

            lstplayer.Add(new Player()
            {
                PlayerId=1,
                PlayerName="rahul",
                PlayerTeam="India",
                PlayerCountry="India",
                PlayerAge=35,
                PlayerType="Batsman",
            });

           lstplayer.Add(new Player()
            {
                PlayerId=2,
                PlayerName="rahul",
                PlayerTeam="India",
                PlayerCountry="India",
                PlayerAge=37,
                PlayerType="Bowler",
            });
       
            lstplayer.Add(new Player()
            {
                PlayerId=3,
                PlayerName="rajesh",
                PlayerTeam="Pakistan",
                PlayerCountry="India",
                PlayerAge=30,
                PlayerType="Bowler",
            });
            
           
            return lstplayer;

    }
    }
}