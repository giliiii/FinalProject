//using BsdFinalProject.IRepositories;
//using BsdFinalProject.IServices;
using BsdFinalProject.DTOs;
using BsdFinalProject.IServices;
using BsdFinalProject.Models;
using BsdFinalProject.Repositories;

namespace BsdFinalProject.Services
{
    public class CardService : ICardService
    {
        private readonly CardRepository _repository = new();
        private readonly GiftService _Gservice = new();

        public async Task<IEnumerable<GiftDtoWithSum?>> GetAllMyCard(int Id)
        {
            var cards = await _repository.GetAllMyCard(Id);
            if (cards == null)
                throw new Exception("no cards found for this user");
            var cardsWithDetails = new List<GiftDtoWithSum>();
            foreach (var card in cards)
            {
                var gift = await _Gservice.GetGiftById(card.GiftId);
                if (gift == null)
                    throw new Exception($"no gift found for gift id {card.GiftId}");
                var giftWithSum = new GiftDtoWithSum
                {
                    Name = gift.Name,
                    Description = gift.Description,
                    Cost = gift.Cost,
                    Picture = gift.Picture,
                    CategoryId = gift.CategoryId,
                    DonorId = gift.DonorId,
                    WinnerName = gift.WinnerName,
                    Count = card.Count
                };
                cardsWithDetails.Add(giftWithSum);
            }
            return cardsWithDetails;
        }
        public async Task<Card?> GetCardById(int id)
        {
            return await _repository.GetCardById(id);
        }
        public async Task<IEnumerable<CardDto?>> CreateNewcCards(List<BasketDto> baskets)
        {
            List<Card> cardList = new List<Card>();
            foreach (var card in baskets)
            {
                Card newCard = new Card
                {
                    GiftId = card.GiftId,
                    UserId = card.UserId,
                    BuingDate = DateTime.Now
                };
                cardList.Add(newCard);
            }
            var createdCards = await _repository.CreateNewcCards(cardList);
            if (createdCards == null)
                throw new Exception("Failed to create cards");
            IEnumerable<CardDto?> cardDtos = createdCards.Select(c => new CardDto
            {
                Id = c.Id,
                GiftId = c.GiftId,
                UserId = c.UserId,
                BuingDate = c.BuingDate
            });
            return cardDtos;
        }


    }

}