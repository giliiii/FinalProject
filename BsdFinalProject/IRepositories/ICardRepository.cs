using BsdFinalProject.DTOs;
using BsdFinalProject.Models;

namespace BsdFinalProject.IRepositories
{
    public interface ICardRepository
    {
        Task<IEnumerable<Card?>> CreateNewcCards(List<Card> cards);
        Task<IEnumerable<GroupedCardDto?>> GetAllMyCard(int Id);
        Task<Card?> GetCardById(int id);
    }
}