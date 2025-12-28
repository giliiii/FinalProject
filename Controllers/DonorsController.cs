using FinalProject.Data;
using FinalProject.DTOs;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonorsController : ControllerBase
    {
        private readonly SaleContext _context;
        public DonorsController(SaleContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonorDto>>> GetAll()
        {
            var list = await _context.Donor
                .Select(d => new DonorDto {
                    Id = d.Id,
                    Name = d.Name,
                    Email = d.Email
                })
                .ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DonorDto>> GetById(int id)
        {
            var d = await _context.Donor.FindAsync(id);
            if (d == null) return NotFound();
            return Ok(new DonorDto { Id = d.Id, Name = d.Name, Email = d.Email });
        }

        [HttpPost]
        public async Task<ActionResult<DonorDto>> Create(CreateDonorDto create)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var donor = new Donor { Name = create.Name, Email = create.Email };
            _context.Donor.Add(donor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = donor.Id }, new DonorDto { Id = donor.Id, Name = donor.Name, Email = donor.Email });
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, CreateDonorDto update)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var donor = await _context.Donor.FindAsync(id);
            if (donor == null) return NotFound();
            donor.Name = update.Name;
            donor.Email = update.Email;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var donor = await _context.Donor.FindAsync(id);
            if (donor == null) return NotFound();
            _context.Donor.Remove(donor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}