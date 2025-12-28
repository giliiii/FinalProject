using FinalProject.Data;
using FinalProject.DTOs;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketsController : ControllerBase
    {
        private readonly SaleContext _context;
        public BasketsController(SaleContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasketDto>>> GetAll()
        {
            var list = await _context.Basket
                .Select(b => new BasketDto {
                    Id = b.Id,
                    UserId = b.UserId,
                    GiftId = b.GiftId
                })
                .ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BasketDto>> GetById(int id)
        {
            var b = await _context.Basket.FindAsync(id);
            if (b == null) return NotFound();
            return Ok(new BasketDto { Id = b.Id, UserId = b.UserId, GiftId = b.GiftId });
        }

        [HttpPost]
        public async Task<ActionResult<BasketDto>> Create(CreateBasketDto create)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var basket = new Basket { UserId = create.UserId, GiftId = create.GiftId };
            _context.Basket.Add(basket);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = basket.Id }, new BasketDto { Id = basket.Id, UserId = basket.UserId, GiftId = basket.GiftId });
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, CreateBasketDto update)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var basket = await _context.Basket.FindAsync(id);
            if (basket == null) return NotFound();
            basket.UserId = update.UserId;
            basket.GiftId = update.GiftId;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var basket = await _context.Basket.FindAsync(id);
            if (basket == null) return NotFound();
            _context.Basket.Remove(basket);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}