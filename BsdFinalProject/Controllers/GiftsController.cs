using BsdFinalProject.Data;
using BsdFinalProject.DTOs;
using BsdFinalProject.Models;
using BsdFinalProject.Services;
using FinalProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BsdFinalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GiftsController : ControllerBase
    {
        private readonly SaleContext _context;
        private readonly GiftService _GiftService;
        //public BasketsController(SaleContext context) => _context = context;

        public GiftsController(GiftService giftService, SaleContext context)
        {
            _GiftService = giftService;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<GiftDto>>> GetAllGifts()
        {
            var gifts = await _GiftService.GetAllGifts();
            return Ok(gifts);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GiftDto>> GetGiftById(int id)
        {
            var gift = await _GiftService.GetGiftById(id);
            if (gift == null)
            {
                return NotFound(new { message = $"Gift with ID {id} not found." });
            }
            return Ok(gift);
        }

        
        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult<GiftDto>> CreateNewGift(GiftDto giftDto)
        {
            var createdGift = await _GiftService.CreateNewGift(giftDto);
            return CreatedAtAction(nameof(GetGiftById), new { id = createdGift.Id }, createdGift);
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult<GiftDto>> UpdateGift(int id, GiftDto giftDto)
        {
            if (id != giftDto.Id)
            {
                return BadRequest(new { message = "ID mismatch." });
            }
            var updatedGift = await _GiftService.UpdateGift(giftDto);
            if (updatedGift == null)
            {
                return NotFound(new { message = $"Gift with ID {id} not found." });
            }
            return Ok(updatedGift);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult<GiftDto>> DeleteGift(int id)
        {
            var deletedGift = await _GiftService.DeleteGift(id);
            if (deletedGift == null)
            {
                return NotFound(new { message = $"Gift with ID {id} not found." });
            }
            return Ok(deletedGift);
        }

        [HttpGet("category/{categoryId:int}")]
        public async Task<ActionResult<List<GiftDto>>> GetGiftsByCategory(int categoryId)
        {
            var gifts = await _GiftService.GetGiftsByCategoryId(categoryId);
            if(gifts == null)
            {

                return BadRequest("invalid categiry id");
            }
            return Ok(gifts);
        }

        [HttpGet("cost/{Price1:int}/{Price2:int}")]
        public async Task<ActionResult<List<GiftDto>>> GetGiftsByCost(int Price1, int Price2)
        {
            var gifts = await _GiftService.GetGiftsByCost(Price1, Price2);
            if (gifts == null)
            {
                return BadRequest("price must be non-negative");
            }
            return Ok(gifts);
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<GiftDto>>> GetAll()
        //{
        //    var list = await _context.Gift
        //        .Select(g => new GiftDto
        //        {
        //            Id = g.Id,
        //            Name = g.Name,
        //            Description = g.Description,
        //            Cost = g.Cost,
        //            Picture = g.Picture,
        //            CategoryId = g.CategoryId,
        //            DonorId = g.DonorId,
        //            WinnerName = g.WinnerName
        //        })
        //        .ToListAsync();
        //    return Ok(list);
        //}

        //[HttpGet("{id:int}")]
        //public async Task<ActionResult<GiftDto>> GetById(int id)
        //{
        //    var g = await _context.Gift.FindAsync(id);
        //    if (g == null) return NotFound();
        //    var dto = new GiftDto
        //    {
        //        Id = g.Id,
        //        Name = g.Name,
        //        Description = g.Description,
        //        Cost = g.Cost,
        //        Picture = g.Picture,
        //        CategoryId = g.CategoryId,
        //        DonorId = g.DonorId,
        //        WinnerName = g.WinnerName
        //    };
        //    return Ok(dto);
        //}

        //[HttpPost]
        //public async Task<ActionResult<GiftDto>> Create(CreateGiftDto create)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);
        //    var gift = new Gift
        //    {
        //        Name = create.Name,
        //        Description = create.Description,
        //        Cost = create.Cost,
        //        Picture = create.Picture,
        //        CategoryId = create.CategoryId,
        //        DonorId = create.DonorId
        //    };
        //    _context.Gift.Add(gift);
        //    await _context.SaveChangesAsync();
        //    var dto = new GiftDto
        //    {
        //        Id = gift.Id,
        //        Name = gift.Name,
        //        Description = gift.Description,
        //        Cost = gift.Cost,
        //        Picture = gift.Picture,
        //        CategoryId = gift.CategoryId,
        //        DonorId = gift.DonorId,
        //        WinnerName = gift.WinnerName
        //    };
        //    return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        //}

        //[HttpPut("{id:int}")]
        //public async Task<IActionResult> Update(int id, CreateGiftDto update)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);
        //    var gift = await _context.Gift.FindAsync(id);
        //    if (gift == null) return NotFound();
        //    gift.Name = update.Name;
        //    gift.Description = update.Description;
        //    gift.Cost = update.Cost;
        //    gift.Picture = update.Picture;
        //    gift.CategoryId = update.CategoryId;
        //    gift.DonorId = update.DonorId;
        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}

        //[HttpDelete("{id:int}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var gift = await _context.Gift.FindAsync(id);
        //    if (gift == null) return NotFound();
        //    _context.Gift.Remove(gift);
        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}
    }
}