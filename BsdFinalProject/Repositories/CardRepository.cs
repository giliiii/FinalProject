using BsdFinalProject.Data;
using BsdFinalProject.Models;
using Chocolate.Data;
using Microsoft.EntityFrameworkCore;
using BsdFinalProject.DTOs;
using BsdFinalProject.IRepositories;

namespace BsdFinalProject.Repositories
{
    public class CardRepository : ICardRepository
       
    {
        private readonly SaleContextFactory _saleContextFactory;
        private Lazy<SaleContext> _lazyContext;

        public CardRepository(SaleContextFactory saleContextFactory)
        {
            _saleContextFactory = saleContextFactory;
            _lazyContext = new Lazy<SaleContext>(() => _saleContextFactory.CreateContext());
        }

        private SaleContext _context => _lazyContext.Value;
        public async Task<IEnumerable<GroupedCardDto?>> GetAllMyCard(int Id)
        {
            return await _context.Card
                .Where(b => b.UserId == Id)
                .GroupBy(card => card.GiftId)
                .Select(g => new GroupedCardDto
                {
                    GiftId = g.Key,
                    Count = g.Count()
                })
                  .ToListAsync();

        }

        public async Task<Card?> GetCardById(int id)
        {
            return await _context.Card
                .FirstOrDefaultAsync(c => c.Id == id);
        }


        public async Task<IEnumerable<Card?>> CreateNewcCards(List<Card> cards)
        {
            _context.Card.AddRange(cards);
            await _context.SaveChangesAsync();
            return cards;
        }



        //public async Task<Basket> DeleteOneBasket(int id)//זה id של basket
        //{
        //    var basket = await _context.Basket.FindAsync(id);
        //    if (basket == null) return null;

        //    _context.Basket.Remove(basket);
        //    await _context.SaveChangesAsync();
        //    return basket;
        //}
        //public async Task<bool> DeleteAllBasket(int id)//זה id של user
        //{
        //    var baskets = (await GetAllMyBasket(id)).ToList();
        //    if (baskets == null || baskets.Count == 0) return false;

        //    // Efficient: remove all retrieved entities in one call
        //    _context.Basket.RemoveRange(baskets);
        //    await _context.SaveChangesAsync();
        //    return true;
        //}

    }
}