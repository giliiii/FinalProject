//using BsdFinalProject.IRepositories;
//using BsdFinalProject.IServices;
using BsdFinalProject.Models;
using BsdFinalProject.Repositories;
using BsdFinalProject.DTOs;
using BsdFinalProject.IServices;

namespace BsdFinalProject.Services
{
    public class WinnerService : IWinnerService
    {
        private readonly WinnerRepository _repository = new();
        private readonly GiftRepository _giftRepository = new();

        public async Task<IEnumerable<WinnerDto?>> GetAllWinners()
        {
            var winners = await _repository.GetAllWinners();
            if (winners == null)
                throw new Exception("No winners found.");
            IEnumerable<WinnerDto?> winnerDtos = winners.Select(c => new WinnerDto
            {
                Id = c.Id,
                IdGift = c.IdGift,
                IdUser = c.IdUser
            });
            return winnerDtos;
        }

        public async Task<WinnerDto?> CreateNewWinner(int giftId)
        {
            var existingWinner = await _repository.GetWinnerByGiftId(giftId);
            if (existingWinner != null)
                throw new Exception("Winner for this gift already exists.");
            List<int?> userIds = (await _repository.GetUsersIdForGift(giftId)).ToList();
            if (userIds == null || userIds.Count == 0)
                throw new Exception("No users found for this gift.");
            Random rand = new Random();
            int randomIndex = rand.Next(userIds.Count());
            int? randomUserId = userIds.ElementAt(randomIndex);
            Winner winner = new Winner
            {
                IdGift = giftId,
                IdUser = randomUserId.Value
            };
            var createdWinner = await _repository.CreateNewWinner(winner);
            if (createdWinner == null)
                throw new Exception("Failed to create winner.");
            WinnerDto winnerDto = new WinnerDto
            {
                Id = createdWinner.Id,
                IdGift = createdWinner.IdGift,
                IdUser = createdWinner.IdUser
            };
            return winnerDto;
        }
        public async Task<bool> DeleteAllWinners()
        {

            var winners = await _repository.GetAllWinners();
            if (winners == null)
                throw new Exception("No winners to delete.");
            foreach (var winner in winners)
            {
                var gift = winner.Gift;
                gift.WinnerName = "";
                var g = await _giftRepository.UpdateGift(gift);
                if (g == null)
                    throw new Exception("Failed to update gift while deleting winners.");
            }

            var deletedWinners = await _repository.DeleteAllWinners();
            if (deletedWinners == null)
                throw new Exception("No winners to delete.");
            return true;
        }
    }
}