using BsdFinalProject.Data;
using BsdFinalProject.DTOs;
using BsdFinalProject.Models;
using BsdFinalProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BsdFinalProject.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly SaleContext _context;
        private readonly UserService _service;

        public UsersController(SaleContext context, UserService service)
        {
            _context = context;
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> UserRegister([FromBody] CreateUserDto dto)
        {
            var (success, token, error) = await _service.UserRegister(dto);
            if (!success) return BadRequest(new { error });

            return Created(string.Empty, new { token });
        }

        // New: login endpoint
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var (success, token, error) = await _service.LoginAsync(dto);
            if (!success) return BadRequest(new { error });

            return Ok(new { token });
        }
    }
}