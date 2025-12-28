using FinalProject.Data;
using FinalProject.DTOs;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly SaleContext _context;
        public UsersController(SaleContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var list = await _context.User
                .Select(u => new UserDto {
                    Id = u.Id,
                    Email = u.Email,
                    FullName = u.FullName,
                    Phone = u.Phone,
                    Adress = u.Adress
                })
                .ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var u = await _context.User.FindAsync(id);
            if (u == null) return NotFound();
            return Ok(new UserDto {
                Id = u.Id,
                Email = u.Email,
                FullName = u.FullName,
                Phone = u.Phone,
                Adress = u.Adress
            });
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Create(CreateUserDto create)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = new User {
                Email = create.Email,
                Password = create.Password,
                FullName = create.FullName,
                Phone = create.Phone,
                Adress = create.Adress
            };
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, new UserDto {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                Phone = user.Phone,
                Adress = user.Adress
            });
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, CreateUserDto update)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = await _context.User.FindAsync(id);
            if (user == null) return NotFound();
            user.Email = update.Email;
            user.Password = update.Password;
            user.FullName = update.FullName;
            user.Phone = update.Phone;
            user.Adress = update.Adress;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null) return NotFound();
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}