using BsdFinalProject.Data;
using BsdFinalProject.DTOs;
using BsdFinalProject.Models;
using BsdFinalProject.Services;
using FinalProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BsdFinalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonorsController : ControllerBase
    {
        private readonly SaleContext _context;
        private readonly Services.DonorService _DonorService;
        //public BasketsController(SaleContext context) => _context = context;

        public DonorsController(DonorService donorService, SaleContext context)
        {
            _DonorService = donorService;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonorDto>>> GetAllDonors()
        {
            var donors = await _DonorService.GetAllDonors();
            return Ok(donors);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<DonorDto>> GetDonorById(int id)
        {
            var donor = await _DonorService.GetDonorById(id);
            if (donor == null)
                return NotFound(new {message=$"Donor with ID {id} not found."});
            return Ok(donor);
        }

        [HttpPost]
        public async Task<ActionResult<CreateDonorDto>> CreateNewDonor(CreateDonorDto donorDto)
        {
            try
            {
                var createdDonor = await _DonorService.CreateNewDonor(donorDto);

                if (createdDonor == null)
                    return BadRequest(new { message = "Failed to create donor." });
                return Ok(createdDonor);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult<DonorDto>> UpdateDonor(DonorDto donorDto)
        {
            var updatedDonor = await _DonorService.UpdateDonor(donorDto);
            if (updatedDonor == null)
                return NotFound(new { message = $"Donor with ID {donorDto.Id} not found." });
            return Ok(donorDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<DonorDto>> DeleteDonor(int id)
        {
            var deletedDonor = await _DonorService.DeleteDonor(id);
            if (deletedDonor == null)
                return NotFound(new { message = $"Donor with ID {id} not found." });
            return Ok(deletedDonor);
        }
        [HttpGet("{id:int}/gifts")]
        public async Task<ActionResult<IEnumerable<GiftDto>>> GetDonorGiftList(int id)
        {
            var gifts = await _DonorService.GetDonorGiftList(id);
            if (gifts == null || !gifts.Any())
                return NotFound(new { message = $"No gifts found for Donor with ID {id}." });
            return Ok(gifts);
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<DonorDto>>> GetAll()
        //{
        //    var list = await _context.Donor
        //        .Select(d => new DonorDto {
        //            Id = d.Id,
        //            Name = d.Name,
        //            Email = d.EMail
        //        })
        //        .ToListAsync();
        //    return Ok(list);
        //}

        //[HttpGet("{id:int}")]
        //public async Task<ActionResult<DonorDto>> GetById(int id)
        //{
        //    var d = await _context.Donor.FindAsync(id);
        //    if (d == null) return NotFound();
        //    return Ok(new DonorDto { Id = d.Id, Name = d.Name, Email = d.EMail });
        //}

        //[HttpPost]
        //public async Task<ActionResult<DonorDto>> Create(CreateDonorDto create)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);
        //    var donor = new Donor { Name = create.Name, EMail = create.Email };
        //    _context.Donor.Add(donor);
        //    await _context.SaveChangesAsync();
        //    return CreatedAtAction(nameof(GetById), new { id = donor.Id }, new DonorDto { Id = donor.Id, Name = donor.Name, Email = donor.EMail });
        //}

        //[HttpPut("{id:int}")]
        //public async Task<IActionResult> Update(int id, CreateDonorDto update)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);
        //    var donor = await _context.Donor.FindAsync(id);
        //    if (donor == null) return NotFound();
        //    donor.Name = update.Name;
        //    donor.EMail = update.Email;
        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}

        //[HttpDelete("{id:int}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var donor = await _context.Donor.FindAsync(id);
        //    if (donor == null) return NotFound();
        //    _context.Donor.Remove(donor);
        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}
    }
}