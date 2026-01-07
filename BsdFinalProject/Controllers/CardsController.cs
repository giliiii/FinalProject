using BsdFinalProject.Data;
using BsdFinalProject.DTOs;
using BsdFinalProject.Models;
using BsdFinalProject.Services;
using FinalProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BsdFinalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardsController : ControllerBase
    {
        private readonly SaleContext _context;
        private readonly CardService _CardService;
        //public BasketsController(SaleContext context) => _context = context;

        public CardsController(CardService cardService, SaleContext context)
        {
            _CardService = cardService;
            _context = context;
        }

        [HttpGet("byId/{id:int}")]
        public async Task<ActionResult<CardDto>> GetCardById(int id)
        {
            var card = await _CardService.GetCardById(id);
            if (card == null)
            {
                return NotFound(new { message = $"Card with ID {id} not found." });
            }
            var cardDto = new CardDto
            {
                Id = card.Id,
                UserId = card.UserId,
                GiftId = card.GiftId,
                BuingDate = card.BuingDate
            };
            return Ok(cardDto);
        }

        [HttpGet("myCards")]
        public async Task<ActionResult<IEnumerable<GiftDtoWithSum?>>> GetAllMyCard()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return Unauthorized();
            int newUserId = int.Parse(userId);
            try
            {
                var cards = await _CardService.GetAllMyCard(newUserId);
                return Ok(cards);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }

        }

        [HttpPost("createCards")]
        public async Task<ActionResult<IEnumerable<CardDto?>>> CreateNewcCards([FromBody] List<BasketDto> baskets)
        {
            try
            {
                var createdCards = await _CardService.CreateNewcCards(baskets);
                return Ok(createdCards);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CardDto>>> GetAll()
        //{
        //    var list = await _context.Card
        //        .Select(c => new CardDto
        //        {
        //            Id = c.Id,
        //            UserId = c.UserId,
        //            GiftId = c.GiftId,
        //            BuingDate = c.BuingDate
        //        })
        //        .ToListAsync();
        //    return Ok(list);
        //}

        //[HttpGet("{id:int}")]
        //public async Task<ActionResult<CardDto>> GetById(int id)
        //{
        //    var c = await _context.Card.FindAsync(id);
        //    if (c == null) return NotFound();
        //    return Ok(new CardDto { Id = c.Id, UserId = c.UserId, GiftId = c.GiftId, BuingDate = c.BuingDate });
        //}

        //[HttpPost]
        //public async Task<ActionResult<CardDto>> Create(CreateCardDto create)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);
        //    var card = new Card { UserId = create.UserId, GiftId = create.GiftId, BuingDate = create.BuingDate };
        //    _context.Card.Add(card);
        //    await _context.SaveChangesAsync();
        //    return CreatedAtAction(nameof(GetById), new { id = card.Id }, new CardDto { Id = card.Id, UserId = card.UserId, GiftId = card.GiftId, BuingDate = card.BuingDate });
        //}

        //[HttpPut("{id:int}")]
        //public async Task<IActionResult> Update(int id, CreateCardDto update)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);
        //    var card = await _context.Card.FindAsync(id);
        //    if (card == null) return NotFound();
        //    card.UserId = update.UserId;
        //    card.GiftId = update.GiftId;
        //    card.BuingDate = update.BuingDate;
        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}

        //[HttpDelete("{id:int}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var card = await _context.Card.FindAsync(id);
        //    if (card == null) return NotFound();
        //    _context.Card.Remove(card);
        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}
    }
}