using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ScoreCardManagement.Common.Filters;
using ScoreCardManagement.WebApi.Models;
using ScoreCardManagement.WebApi.Service.Interface;

namespace ScoreCardManagement.WebApi.Service.Implementation
{
    public class PlayerService : IPlayerService
    {
        public readonly ScoreCardManagement.Common.Repository.Interface.IPlayerRepository playerRepository;
        public IMapper mapper;
        public PlayerService(ScoreCardManagement.Common.Repository.Interface.IPlayerRepository _playerRepository, IMapper _mapper)
        {
            playerRepository = _playerRepository;
            mapper = _mapper;
        }
        public async Task CreatePlayerAsync(Player player)
        {
            try
            {
              await playerRepository.CreatePlayerAsync(mapper.Map<ScoreCardManagement.Common.Entities.Player>(player));
            }
            catch(System.Exception ex)
            {
             throw new Exception("Player creation  failed ", ex.InnerException);
            }
        }


        public async Task DeletePlayerAsync(int playerId)
        {
             try
            {
              await playerRepository.DeletePlayerAsync(playerId);
            }
            catch(System.Exception ex)
            {
             throw new Exception("Player didn't found", ex.InnerException);
            }
        }

        public async Task<Player> GetPlayerAsync(int playerId)
        {
             try
            {
               var player = await playerRepository.GetPlayerAsync(playerId);
               return mapper.Map<ScoreCardManagement.Common.Entities.Player, Player>(player);
            }
            catch(System.Exception ex)
            {
             throw new Exception("Player not found ", ex.InnerException);
            }
        }

        public async Task UpdatePlayerAsync(Player player)
        {
             try
            {
             await playerRepository.UpdatePlayerAsync(mapper.Map<ScoreCardManagement.Common.Entities.Player>(player));
            }
            catch(System.Exception ex)
            {
             throw new Exception("Player details not updated", ex.InnerException);
            }
        }

        public async  Task<List<Player>> GetAllPlayerAsync(PlayerFilter playerFilter)
        {
            List<Player> lstPlayer = new List<Player>();
            try
            {
                var player = await playerRepository.GetAllPlayerAsync(playerFilter);
                foreach (var item in player)
                {
                    lstPlayer.Add(mapper.Map<ScoreCardManagement.Common.Entities.Player, Player>(item));
                }
                return lstPlayer;
            }
            catch (System.Exception ex)
            {
                throw new Exception("Player list  not foumd ", ex.InnerException);
            }
        }
    }
}